function validateFirstName() {
    var firstNameInput = document.getElementById("firstName");
    var firstNameValue = firstNameInput.value.trim();
    var firstNameError = document.getElementById("firstNameError");

    // Clear previous error message
    firstNameError.textContent = "";

    // Check if the field is empty
    if (firstNameValue === "") {
        firstNameError.textContent = "First name cannot be empty.";
        return;
    }

    // Check if the input contains only alphabetic characters
    if (!/^[A-Za-z]+$/.test(firstNameValue)) {
        firstNameError.textContent = "First name should contain alphabetic characters only.";
        return;
    }


    // Attach validateFirstName to the onfocusout event
    var firstNameInput = document.getElementById("firstName");
    firstNameInput.addEventListener("focusout", validateFirstName);
}


function validateLastName() {
    var lastNameInput = document.getElementById("lastName");
    var lastNameValue = lastNameInput.value.trim();
    var lastNameError = document.getElementById("lastNameError");

    // Clear previous error message
    lastNameError.textContent = "";

    // Check if the field is empty
    if (lastNameValue === "") {
        lastNameError.textContent = "Last name cannot be empty.";
        return;
    }

    // Check if the input contains only alphabetic characters
    if (!/^[A-Za-z]+$/.test(lastNameValue)) {
        lastNameError.textContent = "Last name should contain alphabetic characters only.";
        return;
    }


    // Attach validateFirstName to the onfocusout event
    var lastNameInput = document.getElementById("lastName");
    lastNameInput.addEventListener("focusout", validateLastName);
}


function validateDateOfBirth() {
    var dateOfBirthInput = document.getElementById("dateOfBirth");
    var dateOfBirthError = document.getElementById("dateOfBirthError");

    var enteredDate = new Date(dateOfBirthInput.value);
    var currentDate = new Date();

    if (enteredDate > currentDate) {
        dateOfBirthError.innerHTML = "Date of birth cannot be a future date.";
    } else {
        dateOfBirthError.innerHTML = "";
    }
}
var emailPattern = @Html.Raw("new RegExp(\"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}$\")");

function validateEmail() {
    var emailInput = document.getElementById("email");
    var emailError = document.getElementById("emailError");

    if (!emailPattern.test(emailInput.value)) {
        emailError.innerHTML = "Invalid email address.";
    } else {
        emailError.innerHTML = "";
    }
}
function validatePhoneNumber() {
    var phoneNumberInput = document.getElementById("phoneNumber");
    var phoneNumberError = document.getElementById("phoneNumberError");

    var phoneNumberPattern = /^\d{10}$/;

    if (!phoneNumberPattern.test(phoneNumberInput.value)) {
        phoneNumberError.innerHTML = "Phone number must be exactly 10 digits.";
    } else {
        phoneNumberError.innerHTML = "";
    }
}
var passwordPattern = @Html.Raw(@"/^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/");

function validatePassword() {
    var passwordInput = document.getElementById("password");
    var confirmPasswordInput = document.getElementById("confirmPassword");
    var passwordError = document.getElementById("passwordError");
    var confirmPasswordError = document.getElementById("confirmPasswordError");
    if (!passwordPattern.test(passwordInput.value)) {
        passwordError.innerHTML = "Password must contain at least 1 uppercase letter, 1 lowercase letter, 1 digit, 1 special symbol, and be at least 8 characters long.";
    } else {
        passwordError.innerHTML = "";
    }
    if (passwordInput.value !== confirmPasswordInput.value) {
        confirmPasswordError.innerHTML = "Passwords do not match.";
    } else {
        confirmPasswordError.innerHTML = "";
    }
}



var countryStateCityMap = {
    "United States": {
        "New York": ["New York City", "Buffalo", "Rochester"],
        "California": ["Los Angeles", "San Francisco", "San Diego"],
        // ...
    },
    "Canada": {
        "Ontario": ["Toronto", "Ottawa", "Mississauga"],
        "Quebec": ["Montreal", "Quebec City", "Laval"],
        // ...
    },
    "United Kingdom": {
        "London": ["London City", "Westminster", "Camden"],
        "Manchester": ["Manchester City Center", "Salford", "Old Trafford"],
        // ...
    },
};

// Get the dropdown elements
var countryDropdown = document.getElementById("countryDropdown");
var stateDropdown = document.getElementById("stateDropdown");
var cityDropdown = document.getElementById("cityDropdown");

// Populate country dropdown
for (var country in countryStateCityMap) {
    var option = document.createElement("option");
    option.value = country;
    option.text = country;
    countryDropdown.appendChild(option);
}
countryDropdown.addEventListener("change", function () {
    var selectedCountry = countryDropdown.value;
    var states = countryStateCityMap[selectedCountry] || {};

    // Clear and populate state dropdown
    stateDropdown.innerHTML = "";
    cityDropdown.innerHTML = "";

    var defaultOption = document.createElement("option");
    defaultOption.value = "";
    defaultOption.text = "Select a state";
    stateDropdown.appendChild(defaultOption); for (var state in states) {
        var stateOption = document.createElement("option");
        stateOption.value = state;
        stateOption.text = state;
        stateDropdown.appendChild(stateOption);
    }
});

// Handle state dropdown change event
stateDropdown.addEventListener("change", function () {
    var selectedCountry = countryDropdown.value;
    var selectedState = stateDropdown.value;
    var cities = countryStateCityMap[selectedCountry][selectedState] || [];

    // Clear and populate city dropdown
    cityDropdown.innerHTML = ""; var defaultOption = document.createElement("option");
    defaultOption.value = "";
    defaultOption.text = "Select a city";
    cityDropdown.appendChild(defaultOption);

    cities.forEach(function (city) {
        var cityOption = document.createElement("option");
        cityOption.value = city;
        cityOption.text = city;
        cityDropdown.appendChild(cityOption);
    });
});

