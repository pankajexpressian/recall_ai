from venv import logger
from flask import Flask, request, jsonify
from transformers import AutoTokenizer, AutoModel
import torch
from langchain_core.documents import Document
from langchain.chains.combine_documents import create_stuff_documents_chain
from langchain_core.prompts import ChatPromptTemplate
from langchain_huggingface import HuggingFaceEndpoint
from huggingface_hub import login
from logging import Logger

app = Flask(__name__)

# Load pre-trained model and tokenizer for embeddings
model_name = "sentence-transformers/all-MiniLM-L6-v2"
tokenizer = AutoTokenizer.from_pretrained(model_name)
model = AutoModel.from_pretrained(model_name)

# Route to get embeddings
@app.route('/get_embedding', methods=['POST'])
def get_embedding():
    data = request.json
    sentences = data.get("sentences", [])

    if not sentences:
        return jsonify({"error": "No sentences provided"}), 400

    inputs = tokenizer(sentences, return_tensors='pt', padding=True, truncation=True)

    with torch.no_grad():
        outputs = model(**inputs)
        embeddings = outputs.last_hidden_state.mean(dim=1).tolist()

    return jsonify({"embeddings": embeddings})


# Authenticate with Hugging Face
def authenticate_huggingface(token):
    login(token=token)

# Function to search notes based on query and context
def search_notes_huggingface(query, diary_entries, hf_token):
     # Get the number of diary entries
    num_entries = len(diary_entries)

    # Generate dynamic top_indices based on the number of entries
    # Here, I'm selecting the top N entries, or all if there are fewer than N entries
    N = min(5, num_entries)  # Set 3 as the maximum number of top entries, adjust if necessary
    top_indices = list(range(N))  # Dynamic indices based on the number of entries

    # Fetch corresponding diary entries
    doc = []
    for idx in top_indices:
        doc.append(Document(page_content=diary_entries[idx], metadata={"source": "local"}))

    # Log in to Hugging Face
    authenticate_huggingface(hf_token)

    # Initialize Hugging Face model
    model_id = 'mistralai/Mistral-7B-Instruct-v0.3'
    llm = HuggingFaceEndpoint(repo_id=model_id, max_length=128, temperature=0.7, token=hf_token)

    # Create a LangChain prompt
    prompt = ChatPromptTemplate.from_template(
        "You are an assistant who answers user based on the notes documented by user in the context: {context}. "
        "Based on this user query: {query} and using the context, provide an answer as a friend.Don't include I with user query always response like you and I always use in case of your sentences."
    )

    # Create LangChain document processing chain
    chain = create_stuff_documents_chain(llm, prompt)

    # Pass the query and document context to the chain
    result = chain.invoke({"query": query, "context": doc})

    return result

# Route to search notes
@app.route('/search-notes', methods=['POST'])
def search_notes():
    try:
        data = request.get_json()
        logger.info("Received data: %s", data)
        query = data['query']
        diary_entries = data['diary_entries']  # List of diary entries
        hf_token = data['huggingface_token']  # Hugging Face API token
        logger.info(query, diary_entries, hf_token)
        # Call the search notes function
        result = search_notes_huggingface(query, diary_entries, hf_token)

        return jsonify({"result": result}), 200
    except Exception as e:
        return jsonify({"error": str(e)}), 500


if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)

