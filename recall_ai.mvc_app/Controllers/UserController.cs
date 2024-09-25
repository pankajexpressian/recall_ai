using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using recall_ai.mvc_app.Models;
using System.Text;


namespace YourMvcApp.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;

        // HttpClient injected by DI
        public UserController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new System.Uri("http://localhost:5076/api/"); // Base API URL
        }

        // Get all users
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("users");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<User>>(jsonResponse);
                return View(users); // Pass users to the view
            }

            return View("Error");
        }

        // Get user by ID
        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"users/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(jsonResponse);
                return View(user); // Pass user to the view
            }

            return View("Error");
        }

        // Create a new user (GET method to show form)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Create a new user (POST method to submit form)
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                var jsonUser = JsonConvert.SerializeObject(user);
                var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("users", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index"); // Redirect to list of users after success
                }
            }

            return View(user);
        }

        // Update a user (GET method to show form)
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"users/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(jsonResponse);
                return View(user);
            }

            return View("Error");
        }

        // Update a user (POST method to submit form)
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var jsonUser = JsonConvert.SerializeObject(user);
                var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"users/{user.UserId}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(user);
        }

        // Delete a user
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"users/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Error");
        }



        [HttpGet]
        public IActionResult SignInSignUp()
        {
            return View();
        }

    //    // Handle Sign In
    //    [HttpPost]
    //    public async Task<IActionResult> SignIn(string signInEmail)
    //    {
    //        if (string.IsNullOrWhiteSpace(signInEmail))
    //        {
    //            ModelState.AddModelError("", "Email is required.");
    //            return View("SignInSignUp");
    //        }

    //        // Logic for checking if user exists, etc.
    //        // Assume you have an API call to check if the user exists and log in

    //        var userExists = true; // Simulating a check (replace with actual API call)
    //        if (userExists)
    //        {
    //            // Simulate sign-in logic and redirect
    //            return RedirectToAction("Index", "Home");
    //        }
    //        else
    //        {
    //            ModelState.AddModelError("", "No user found with that email.");
    //            return View("SignInSignUp");
    //        }
    //    }

    //    // Handle Sign Up
    //    [HttpPost]
    //    public async Task<IActionResult> SignUp(SignInSignUpModel model)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return View("SignInSignUp", model);
    //        }

    //        // Logic for signing up the user
    //        // Assume an API call to create a new user

    //        // Simulate success response
    //        var success = true; // Replace with actual API response handling
    //        if (success)
    //        {
    //            return RedirectToAction("Index", "Home");
    //        }
    //        else
    //        {
    //            ModelState.AddModelError("", "There was an error creating the account.");
    //            return View("SignInSignUp", model);
    //        }
    //    }
    }
}




//using Microsoft.AspNetCore.Mvc;

//namespace recall_ai.mvc_app.Controllers
//{
//    public class UserController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }
//    }
//}
