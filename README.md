# 🖥️ Portfolio Terminal Website

Welcome to my **Portfolio Terminal Website**! This project is a unique and interactive way to showcase my professional experience, skills, and projects through a **terminal-inspired user interface**. Designed to replicate the look and feel of an old-school command-line interface, this project combines creativity and cutting-edge technology.

---

## 🚀 **Features**
- **Interactive Command-Line Interface**: Users can type commands to navigate through the portfolio sections.
- **AI-Powered Chatbot**: Integrated with a chatbot API to answer questions about my skills, experience, and projects.
- **Dynamic Content**: The portfolio dynamically loads data such as professional experience, technical skills, and project details from a structured JSON file.
- **Restricted Topics**: Sensitive or personal topics are excluded from chatbot responses to maintain a professional focus.
- **Scalable Backend**: Built with .NET Core to handle API requests securely.
- **API Documentation**: Swagger is configured for clear and easy-to-understand API endpoint documentation.

---

## 🛠 **Technologies Used**

### **Frontend**
- **Angular**: For building a robust and dynamic user interface.
- **Tailwind CSS**: For responsive and modern styling.

### **Backend**
- **.NET Core**: For developing scalable and efficient APIs.
- **Swagger**: For API documentation and testing.

### **Other Tools**
- **TypeScript**: To ensure strong typing and maintainable code.
- **Git**: For version control and collaboration.

---

## 📝 **How It Works**
1. **Terminal-Style Navigation**:
   - Users can navigate through the portfolio by entering commands such as:
     - `about` – Learn more about me.
     - `skills` – Display my technical skills.
     - `experience` – Show my professional experience.
     - `projects` – View details of my completed projects.
     - `contact` – Display my GitHub, LinkedIn, and email.
     ### Navigation & Command History
      - **Arrow Keys (↑ and ↓):** Use the up and down arrow keys to navigate through your command history, making it easier to re-execute previously typed commands.
      - **Tab Key:** Use the tab key to auto-complete commands (if applicable).

2. **Chatbot Integration**:
   - An AI chatbot provides responses based on the commands entered by the user. It is trained to answer questions about my background, avoiding sensitive topics.

3. **Backend API**:
   - The backend processes commands via API endpoints, fetches data from structured JSON files, and returns the appropriate responses.

4. **API Documentation**:
   - Swagger is available at `/swagger` to view and test API endpoints.
   

### **Steps**
1. Clone the repository:
   git clone https://github.com/igor-benites/portfolio-terminal.git

    Frontend Setup:
        Navigate to the src folder.
        Install dependencies:
npm install
Run the Angular development server:
ng serve
    Access the frontend at http://localhost:4200.

Backend Setup:
    Navigate to the api folder.
    Install dependencies and run the server:
dotnet restore
dotnet run
    Access the backend at http://localhost:5115.

Swagger API Documentation:
    Open your browser and navigate to:
http://localhost:5115/swagger
