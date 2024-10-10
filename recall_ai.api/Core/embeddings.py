# embeddings.py
from sentence_transformers import SentenceTransformer

model = SentenceTransformer('sentence-transformers/all-MiniLM-L6-v2')

def get_embeddings(text):
    return model.encode(text).tolist()  # Convert to list for easy serialization
