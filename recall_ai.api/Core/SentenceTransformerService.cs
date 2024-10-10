//using Python.Runtime;

//public class SentenceTransformerService
//{
//    public SentenceTransformerService()
//    {
//        // Initialize the Python engine
//        PythonEngine.Initialize();
//    }

//    public float[] GetEmbeddings(string text)
//    {
//        using (Py.GIL())
//        {
//            // Import your Python script
//            dynamic embeddingsModule = Py.Import("embeddings");

//            // Call the get_embeddings function
//            dynamic result = embeddingsModule.get_embeddings(text);

//            // Convert the result to a float array
//            return result.ToArray<float>(); // Ensure the output is a float array
//        }
//    }

//    public void Dispose()
//    {
//        // Clean up the Python engine when done
//        PythonEngine.Shutdown();
//    }
//}
