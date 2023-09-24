import tkinter as tk
from tkinter import ttk

class Combatant:
    def __init__(self, name, initiative, hp):
        self.name = name
        self.initiative = initiative
        self.hp = hp
        self.max_hp = hp
        self.damage_taken = 0

# Create an empty list to store combatants
combatants = []

# Create a list to store Entry widgets for damage input
damage_entries = []

# Create a list to store the "Assign Damage to Combatant" buttons
assign_damage_buttons = []

# Create the main application window
root = tk.Tk()
root.title("Combat Tracker")

# Function to add a new combatant to the list
def add_combatant():
    row = current_row[0]  # Get the current row from the list
    name = name_entry.get()
    initiative = int(initiative_entry.get())
    hp = int(hp_entry.get())

    combatant = Combatant(name, initiative, hp)
    combatants.append(combatant)

    # Sort combatants by initiative in descending order
    combatants.sort(key=lambda x: x.initiative, reverse=True)

    # Clear the Treeview
    initiative_list.delete(*initiative_list.get_children())

    # Update the Treeview with all combatants
    for i, combatant in enumerate(combatants, start=1):
        initiative_list.insert("", "end", values=(i, combatant.name, combatant.initiative, f"{combatant.hp}/{combatant.max_hp}"))

        # Update the "Assign Damage to All" button command
        update_assign_all_button()

        # Create Entry widget for damage input
        damage_entry = tk.Entry(root)
        damage_entry.grid(row=row, column=0)
        damage_entries.append(damage_entry)

        # Create "Assign Damage to Combatant" button
        assign_damage_button = tk.Button(root, text=f"Assign Damage to {combatant.name}", command=lambda c=combatant, entry=damage_entry: assign_damage(c, entry))
        assign_damage_button.grid(row=row, column=1)
        assign_damage_buttons.append(assign_damage_button)

    # Clear text fields for damage input
    name_entry.delete(0, tk.END)
    initiative_entry.delete(0, tk.END)
    hp_entry.delete(0, tk.END)

    # Increment the row variable
    current_row[0] += 1

# Function to update combatant data in the combatants list
def update_combatant_data():
    for i, combatant in enumerate(combatants):
        combatant.hp = int(initiative_list.item(i + 1, "values")[3].split("/")[0])
        combatant.damage_taken = combatant.max_hp - combatant.hp

# Function to update the "Assign Damage to All" button command
def update_assign_all_button():
    if combatants:
        assign_all_button.config(command=assign_damage_to_all)
    else:
        assign_all_button.config(command=lambda: None)

# Function to simulate a combat round
def simulate_combat_round():
    # Clear the result_text widget to start a new round
    result_text.delete(1.0, tk.END)
    
    # Create a list to store defeated combatants
    defeated_combatants = []
    
    # Iterate through combatants and display their HP status
    for combatant in combatants:
        result_text.insert(tk.END, f"{combatant.name}'s HP: {combatant.hp - combatant.damage_taken}/{combatant.max_hp}\n")
        
        if combatant.hp - combatant.damage_taken <= 0:
            result_text.insert(tk.END, f"{combatant.name} has been defeated!\n")
            defeated_combatants.append(combatant)
    
    # Remove defeated combatants from the combatants list
    for defeated in defeated_combatants:
        combatants.remove(defeated)
    
    # Clear text fields for damage input
    for damage_entry in damage_entries:
        damage_entry.delete(0, tk.END)

        

# Function to assign damage to a combatant
def assign_damage(combatant, damage_entry):
    damage = int(damage_entry.get())
    combatant.damage_taken += damage
    result_text.insert(tk.END, f"{damage} damage assigned to {combatant.name}\n")
    # Update Damage Taken and HP in the initiative tracker for this combatant


def assign_damage_to_all():
    for i, combatant in enumerate(combatants):
        damage_str = damage_entries[i].get()
        if damage_str.strip():  # Check if the string is not empty after stripping whitespace
            damage = int(damage_str)
            combatant.damage_taken += damage
            result_text.insert(tk.END, f"{damage} damage assigned to {combatant.name}\n")




# Function to update HP and Damage Taken in the initiative tracker
def update_hp_damage_in_initiative_tracker(combatant):
    for i, existing_combatant in enumerate(combatants, start=1):
        if existing_combatant == combatant:
            updated_hp = combatant.hp - combatant.damage_taken
            initiative_list.item(i, values=(i, combatant.name, combatant.initiative, f"{updated_hp}/{combatant.max_hp}", combatant.damage_taken))
            # Call update_combatant_data to update the combatants list



# Function to clear all combatants
def clear_combatants():
    combatants.clear()
    damage_entries.clear()
    for button in assign_damage_buttons:
        button.grid_forget()  # Remove the "Assign Damage to Combatant" buttons
    assign_damage_buttons.clear()
    initiative_list.delete(*initiative_list.get_children())
    result_text.delete(1.0, tk.END)

    # Update the "Assign Damage to All" button command
    update_assign_all_button()

    # Clear text fields for damage input
    name_entry.delete(0, tk.END)
    initiative_entry.delete(0, tk.END)
    hp_entry.delete(0, tk.END)


# Initialize the row variable as a mutable list
current_row = [8]

# Create and place widgets
name_label = tk.Label(root, text="Name:")
name_label.grid(row=0, column=0, padx=5, pady=5, sticky="w")
name_entry = tk.Entry(root)
name_entry.grid(row=0, column=0, padx=6, pady=5)

initiative_label = tk.Label(root, text="Initiative:")
initiative_label.grid(row=1, column=0, padx=5, pady=5, sticky="w")
initiative_entry = tk.Entry(root)
initiative_entry.grid(row=1, column=0, padx=6, pady=5)

hp_label = tk.Label(root, text="HP:")
hp_label.grid(row=2, column=0, padx=5, pady=5, sticky="w")
hp_entry = tk.Entry(root)
hp_entry.grid(row=2, column=0, padx=6, pady=5)

add_button = tk.Button(root, text="Add Combatant", command=add_combatant)
add_button.grid(row=3, column=0, columnspan=1, padx=5, pady=5)

# Create the Treeview widget for the initiative tracker with columns
initiative_list = ttk.Treeview(root, columns=("ID", "Name", "Initiative", "HP"), show="headings")
initiative_list.grid(row=4, column=0, columnspan=1, padx=5, pady=5)

# Define column headers and set column widths
columns = ("ID", "Name", "Initiative", "HP")
headers = ("ID", "Name", "Initiative", "HP")
widths = (30, 150, 80, 80)

for col, header, width in zip(columns, headers, widths):
    initiative_list.heading(col, text=header)
    initiative_list.column(col, width=width)

# Style for the Treeview
style = ttk.Style()
style.configure("Treeview",
                background="white",
                fieldbackground="white",
                foreground="black",
                font=("Helvetica", 12))
style.configure("Treeview.Heading", font=("Helvetica", 12, "bold"))

# Create and place widgets
clear_button = tk.Button(root, text="Clear All Combatants", command=clear_combatants)
clear_button.grid(row=5, column=0, padx=5, pady=5)

# Create the "Assign Damage to All" button
assign_all_button = tk.Button(root, text="Assign Damage to All", command=assign_damage_to_all)
assign_all_button.grid(row=5, column=1, padx=5, pady=5)

simulate_button = tk.Button(root, text="Simulate Combat Round", command=simulate_combat_round)
simulate_button.grid(row=6, column=0, padx=5, pady=5)

result_text = tk.Text(root)
result_text.grid(row=7, column=0, columnspan=3, padx=5, pady=5)

# Main loop
root.mainloop()