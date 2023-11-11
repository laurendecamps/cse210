using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop02 World!");
    }
}
import random
import datetime

class Journal:
    def __init__(self):
        self.entries = []

    def write_entry(self):
        prompts = [
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        ]
        prompt = random.choice(prompts)
        response = input(f"{prompt}\nYour response: ")
        date = datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")
        entry = {"prompt": prompt, "response": response, "date": date}
        self.entries.append(entry)
        print("Entry saved successfully!")

    def display_journal(self):
        if not self.entries:
            print("No entries found.")
        else:
            for entry in self.entries:
                print(f"\nDate: {entry['date']}\nPrompt: {entry['prompt']}\nResponse: {entry['response']}")

    def save_to_file(self):
        filename = input("Enter the filename to save the journal: ")
        with open(filename, "w") as file:
            for entry in self.entries:
                file.write(f"Date: {entry['date']}\nPrompt: {entry['prompt']}\nResponse: {entry['response']}\n\n")
        print("Journal saved to file successfully!")

    def load_from_file(self):
        filename = input("Enter the filename to load the journal from: ")
        try:
            with open(filename, "r") as file:
                entries = []
                lines = file.readlines()
                for i in range(0, len(lines), 4):
                    entry = {
                        "date": lines[i].strip("\n").split(": ")[1],
                        "prompt": lines[i + 1].strip("\n").split(": ")[1],
                        "response": lines[i + 2].strip("\n").split(": ")[1]
                    }
                    entries.append(entry)
                self.entries = entries
            print("Journal loaded from file successfully!")
        except FileNotFoundError:
            print("File not found.")

def main():
    my_journal = Journal()

    while True:
        print("\n=== Journal Menu ===")
        print("1. Write a new entry")
        print("2. Display the journal")
        print("3. Save the journal to a file")
        print("4. Load the journal from a file")
        print("5. Quit")

        choice = input("Enter your choice (1-5): ")

        if choice == "1":
            my_journal.write_entry()
        elif choice == "2":
            my_journal.display_journal()
        elif choice == "3":
            my_journal.save_to_file()
        elif choice == "4":
            my_journal.load_from_file()
        elif choice == "5":
            print("Goodbye!")
            break
        else:
            print("Invalid choice. Please enter a number between 1 and 5.")

if __name__ == "__main__":
    main()
