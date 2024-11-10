# Recall AI

This project integrates AI models for the Recall AI platform. Below are the steps to set up the project and run both the backend and frontend applications.

## Codebase

You can view the codebase [here](https://github.com/pankajexpressian/recall_ai/tree/AIModels).

## Cloning the Repository

To clone the repository, use the following command:

```bash
git clone https://github.com/pankajexpressian/recall_ai.git
```

After cloning, switch to the `AIModels` branch:

```bash
git checkout AIModels
```

## Running the Backend

### Step 1: Navigate to the `recall_ai.api` directory

```bash
cd recall_ai.api
```

### Step 2: Build and run the .NET application

To build the backend application, run:

```bash
dotnet build
```

Then, to start the backend application:

```bash
dotnet run
```

## Running the Frontend

### Step 1: Navigate to the `recall_ai_ui` directory

Open a new terminal window and change to the frontend directory:

```bash
cd recall_ai_ui
```

### Step 2: Install dependencies

Install the necessary dependencies using:

```bash
npm install
```

### Step 3: Run the frontend application

To start the frontend application, use the following command:

```bash
ng serve --port=4200
```
### Step 3: Run the python application
Flask Application with Hugging Face Integration
This application provides two endpoints:

/get_embedding: Returns embeddings for input sentences.
/search-notes: Searches diary entries based on user queries, utilizing Hugging Face's language model.

Prerequisites
Python 3.7+
A Hugging Face API token

File location
Code files are available under "recall_ai.api\Core"
Setup
1. Open above folder location in VS code run the following steps.
a. Create a Virtual Environment
Create a virtual environment to manage dependencies and run below commands in terminal:

python3 -m venv venv

Activate the virtual environment:

On Windows:
venv\Scripts\activate

On macOS/Linux:
source venv/bin/activate

3. Install Dependencies
Create a requirements.txt file if it doesn't already exist, and add the following dependencies:

text
Copy code
flask
torch
transformers
langchain-core
langchain-huggingface
huggingface_hub
Then, install the dependencies:

pip install -r requirements.txt

4. Set Up Hugging Face Authentication
You’ll need a Hugging Face API token to access models. Save your token for use in the /search-notes endpoint.

5. Run the Application
With the virtual environment activated, start the Flask application:

python embeddings.py
The server will run on http://0.0.0.0:5000.

### Step 5: Access the Application

Open your browser and go to `http://localhost:4200` to interact with the fully functional application.

---

Usage
1. Test the /get_embedding Endpoint
Send a POST request with a JSON payload containing sentences to receive embeddings.

Example Request:

bash
Copy code
curl -X POST http://localhost:5000/get_embedding -H "Content-Type: application/json" -d "{\"sentences\": [\"This is a test sentence.\"]}"
Expected Response:

json
Copy code
{
  "embeddings": [[...]]
}
2. Test the /search-notes Endpoint
Send a POST request to search diary entries based on a query, with authentication to Hugging Face.

Example Request:

bash
Copy code
curl -X POST http://localhost:5000/search-notes -H "Content-Type: application/json" -d "{\"query\": \"search text\", \"diary_entries\": [\"entry 1\", \"entry 2\"], \"huggingface_token\": \"your_token_here\"}"
Expected Response:

json
Copy code
{
  "result": "Generated response based on notes and query"
}
Note: Replace "your_token_here" with a valid Hugging Face token.
Feel free to contribute or report any issues!
```

This structure will make it clear and easy to follow for anyone setting up the project.

*********************************************************************************************************************
Expected Outcomes:
•	A working prototype/polished functional interface that demonstrates the application of Generative AI in a business context.
•	Final codebase
•	Basic setup and usage documentation
•	A detailed presentation that outlines the problem, the solution, its viability, and potential impact on the industry.
