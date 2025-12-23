# OpenRouter Console Chat App

A simple C# console application to interact with **OpenRouter API** for chatting with AI models like `gpt-4o-mini`. This app supports **continuous conversation** and keeps the chat history.

---

## Features

* Ask questions and get AI responses.
* Continuous conversation in a loop.
* Keeps chat history for context.
* Type `exit` to end the chat.

---

## Requirements

* .NET 6 or later
* OpenRouter API key

---

## Setup

1. Clone or download this repository.
2. Open the project in Visual Studio or VS Code.
3. Replace your API key in `Program.cs`:

```csharp
string apiKey = "YOUR_OPENROUTER_API_KEY";
```

4. (Optional) Change the model if you want:

```csharp
string model = "gpt-4o-mini";
```

---

## Usage

1. Run the console app:

```bash
dotnet run
```

2. Type your question and press Enter.
3. The assistant will respond.
4. Keep chatting continuously.
5. Type `exit` to quit.

---

## OpenRouter API Limits

* **20 requests per minute**
* **50 requests per day**

> Make sure to not exceed these limits to avoid errors.

---

## Example

```
You: Hello!
Assistant: Hi there! How can I help you today?
You: Tell me a joke.
Assistant: Why did the computer go to the doctor? Because it caught a virus! 😄
You: exit
Chat ended.
```

---

## Notes

* Keep your API key secure.
* Chat history is stored only in memory during runtime.
* For multiple or advanced conversations, consider persisting messages.

