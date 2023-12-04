# Sending Email with Power Automate

## Overview
This repository contains an ASP.NET Core MVC web application that uses Power Automate to send emails. The application accepts user input through a contact form and uses an HTTP POST request to trigger a Power Automate flow, which then sends an email.

## Prerequisites
- .NET Core SDK
- Visual Studio (recommended for ease of use with ASP.NET Core)
- Access to Microsoft Power Automate


## Components

### ContactUs Model
- Holds the data structure for the contact form.
### Contact View
- An ASP.NET Core Razor view that renders the contact form.
### Controller
- Handles the HTTP GET and POST requests for the contact form.
Sends data to Power Automate on form submission.

## Setting Up Power Automate
1. On Power Automate Home Page Select Instant Cloud Flow
2.  Select Trigger Flow: When an HTTP request is received Request
3. Add this Request Body JSON Schema
{
    "type": "object",
    "properties": {
        "Name": {
            "type": "string",
            "description": "The full name of the user."
        },
        "Email": {
            "type": "string",
            "format": "email",
            "description": "The email address of the user."
        },
        "MessageBody": {
            "type": "string",
            "description": "The main content of the user's message."
        }
    },
    "required": ["Name", "Email", "MessageBody"]
}

4.  Add Action Send an email (V2)
5. Copy the HTTP POST URL generated by Power Automate to use in your application's controller.


   
## Configuration in the MVC Application
Update the controller's HttpClient POST URL to match the one provided by your Power Automate flow.


## Usage
- Navigate to the Contact page from the application's menu.
- Fill out the form with your Name, Email, and Message.
- Click the Send button to send the message.
- The application will process the request and send the data to Power Automate, which then sends an email.
