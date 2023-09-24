import random
import tkinter as tk
from tkinter import ttk
from collections import Counter

#Create the main application window
root = tk.Tk()
root.title("D&D Encounter Generator")
frame = None  # Initialize the frame variable
# Define a mapping of monsters to their Challenge Ratings (CR) and environments
monster_info = {
    "Goblin": {"cr": 0.25, "environment": "Forest"},
    "Orc": {"cr": 0.5, "environment": "Plains"},
    "Hobgoblin": {"cr": 1.0, "environment": "Mountain"},
    "Bugbear": {"cr": 2.0, "environment": "Forest"},
    "Ogre": {"cr": 2.5, "environment": "Swamp"},
    "Troll": {"cr": 5.0, "environment": "Swamp"},
    "Young Dragon": {"cr": 7.0, "environment": "Mountain"},
    "Bandit": {"cr": 1/8, "environment": "Plains"},
    "Thug": {"cr": 1/2, "environment": "Urban"},
    "Owl": {"cr": 0, "environment": "Forest"},
    "Wolf": {"cr": 1/4, "environment": "Forest"},
    "Giant Eagle": {"cr": 1, "environment": "Mountain"},
    "Giant Elk": {"cr": 2, "environment": "Forest"},
    "Giant Boar": {"cr": 2, "environment": "Forest"},
    "Giant Ape": {"cr": 5, "environment": "Jungle"},
    "Ochre Jelly": {"cr": 2, "environment": "Cave"},
    "Giant Scorpion": {"cr": 3, "environment": "Desert"},
    "Giant Spider": {"cr": 1, "environment": "Forest"},
    "Giant Toad": {"cr": 1, "environment": "Swamp"},
    "Giant Rat": {"cr": 1/8, "environment": "Sewer"},
    "Giant Centipede": {"cr": 1/4, "environment": "Underground"},
    "Giant Lizard": {"cr": 1/4, "environment": "Swamp"},
    "Giant Crab": {"cr": 1/8, "environment": "Coast"},
    "Giant Snake": {"cr": 1, "environment": "Swamp"},
    "Giant Octopus": {"cr": 1, "environment": "Ocean"},
    "Giant Crocodile": {"cr": 5, "environment": "Swamp"},
    "Giant Shark": {"cr": 5, "environment": "Ocean"},
    "Giant Hyena": {"cr": 1, "environment": "Plains"},
    "Giant Badger": {"cr": 1/4, "environment": "Forest"},
    "Giant Weasel": {"cr": 1/8, "environment": "Forest"},
    "Giant Goat": {"cr": 1/2, "environment": "Mountain"},
    "Giant Stag Beetle": {"cr": 1, "environment": "Forest"},
    "Giant Wasp": {"cr": 1/2, "environment": "Forest"},
    "Giant Owl": {"cr": 1/4, "environment": "Forest"},
    "Giant Bat": {"cr": 1/4, "environment": "Cave"},
    "Giant Frog": {"cr": 1/4, "environment": "Swamp"},
    "Skeleton": {"cr": 1/4, "environment": "Crypt"},
    "Zombie": {"cr": 1/4, "environment": "Crypt"},
    "Ghoul": {"cr": 1, "environment": "Crypt"},
    "Vampire": {"cr": 13, "environment": "Crypt"},
    "Lich": {"cr": 21, "environment": "Crypt"},
}

# Define environments and their associated monsters
environments = {
    "Forest": ["Goblin", "Bugbear", "Owl", "Wolf", "Giant Eagle", "Giant Elk", "Giant Boar", "Giant Spider", "Giant Badger", "Giant Stag Beetle", "Giant Weasel"],
    "Plains": ["Orc", "Bandit"],
    "Mountain": ["Hobgoblin", "Young Dragon", "Giant Ape", "Giant Eagle", "Giant Elk", "Giant Boar", "Giant Stag Beetle"],
    "Swamp": ["Ogre", "Troll", "Giant Toad", "Giant Lizard", "Giant Frog", "Giant Crab"],
    "Desert": ["Giant Scorpion", "Giant Vulture"],
    "Jungle": ["Giant Ape"],
    "Cave": ["Ochre Jelly", "Giant Bat", "Giant Centipede", "Giant Spider"],
    "Underground": ["Giant Centipede", "Giant Lizard"],
    "Sewer": ["Giant Rat"],
    "Coast": ["Giant Crab"],
    "Ocean": ["Giant Octopus", "Giant Shark"],
    "Crypt": ["Skeleton", "Zombie", "Ghoul", "Vampire", "Lich"],
    # Add more environments and associated monsters as needed
}

player_level_entries = []
player_intelligence_var = tk.StringVar()  # Variable to store player intelligence
player_intelligence_combobox = None  # Combobox for player intelligence

# Define missing variables here
difficulty_combobox = ttk.Combobox(root, values=["Easy", "Medium", "Hard", "Deadly"])
environment_combobox = ttk.Combobox(root, values=list(environments.keys()))
result_label = ttk.Label(root, text="Selected Monsters:")
difficulty_var = tk.StringVar()  # Define the variable for desired difficulty
environment_var = tk.StringVar()  # Define the variable for selected environment
# Constants
XP_THRESHOLD = 100

def update_players():
    global player_level_entries
    num_players = int(num_players_entry.get())

    # Remove existing player level entries
    for entry in player_level_entries:
        entry.grid_forget()
    player_level_entries = []

    # Create and place new player level entries based on the updated number of players
    for i in range(num_players):
        ttk.Label(root, text=f"Player {i + 1} Level:").grid(column=0, row=i + 2, sticky=tk.W)
        entry = ttk.Entry(root)
        entry.grid(column=1, row=i + 2)
        player_level_entries.append(entry)

      # Create and place player intelligence entry
    global player_intelligence_entry
    ttk.Label(root, text="Player Intelligence:").grid(column=0, row=num_players + 2, sticky=tk.W)
    player_intelligence_entry = ttk.Entry(root)
    player_intelligence_entry.grid(column=1, row=num_players + 2)

# Function to clear the previous results
def clear_results():
    result_label.config(text="Selected Monsters:")

def generate_encounter():
    player_levels = [int(entry.get()) for entry in player_level_entries]
    num_players = len(player_levels)
    
    if num_players == 0:
        result_label.config(text="No player levels entered.")
        return
    
    apl = sum(player_levels) / num_players
    desired_difficulty = difficulty_combobox.get()
    selected_environment = environment_combobox.get().capitalize()
    
    if selected_environment not in environments:
        result_label.config(text="Invalid environment selection.")
        return
    
    available_monsters = environments[selected_environment]
    
    if desired_difficulty == "Easy":
        base_cr = apl
    elif desired_difficulty == "Medium":
        base_cr = apl + 1
    elif desired_difficulty == "Hard":
        base_cr = apl + 2
    elif desired_difficulty == "Deadly":
        base_cr = apl + 3
    else:
        result_label.config(text="Invalid difficulty level.")
        return

    # Adjust the Challenge Rating (CR) based on the number of players
    if num_players == 1:
        cr = base_cr - 1  # Decrease CR for solo player
    elif num_players > 4:
        cr = base_cr + 1  # Increase CR for large parties
    else:
        cr = base_cr

    selected_monsters = []
    total_xp = 0
    
    while total_xp < cr * 100:
        available_monsters = [monster for monster in available_monsters if total_xp + monster_info[monster]["cr"] * 100 <= cr * 100]
        
        if not available_monsters:
            break
        
        random_monster = random.choice(available_monsters)
        cr_value = monster_info[random_monster]["cr"]
        
        selected_monsters.append(random_monster)
        total_xp += cr_value * 100
    
    # Display the selected monsters in the result_label
    result_label.config(text="Selected Monsters:\n" + "\n".join(selected_monsters))
    
    # Count the duplicates of each selected monster
    monster_counts = Counter(selected_monsters)
    
    # Create a list of formatted strings for each monster and its count
    formatted_monsters = [f"{count} - {monster}" for monster, count in monster_counts.items()]
    
    # Display the selected monsters in the result_label
    result_label.config(text="Selected Monsters:\n" + "\n".join(formatted_monsters))

    
# Function to update the GUI based on the number of player levels
def update_gui():
    num_players = int(num_players_entry.get())
    
    # Clear existing widgets for Desired Difficulty and Select Environment
    for widget in frame.winfo_children():
        widget.grid_forget()
    
    # Clear existing player level fields
    for entry in player_level_entries:
        entry.grid_forget()
    
    # Create player level fields based on the number of players
    player_level_entries.clear()
    for i in range(num_players):
        ttk.Label(frame, text=f"Player {i + 1} Level:").grid(column=0, row=i + 2, sticky=tk.W)
        entry = ttk.Entry(frame)
        entry.grid(column=1, row=i + 2)
        player_level_entries.append(entry)
    
    # Create and position Desired Difficulty label and combobox
    ttk.Label(frame, text="Desired Difficulty:").grid(column=0, row=num_players + 2, sticky=tk.E)
    difficulty_combobox.grid(column=1, row=num_players + 2, sticky=tk.W)

    # Create and position Select Environment label and combobox
    ttk.Label(frame, text="Select Environment:").grid(column=0, row=num_players + 3, sticky=tk.E)
    environment_combobox.grid(column=1, row=num_players + 3, sticky=tk.W)

    # Adjust the alignment of the buttons and result_label
    generate_button.grid(column=0, row=num_players + 4, columnspan=2, sticky=tk.W)
    result_label.grid(column=0, row=num_players + 5, columnspan=2, sticky=tk.W)

    # Create and place a label and combobox for player intelligence
    ttk.Label(root, text="Player Intelligence:").grid(column=0, row=1, sticky=tk.W)
    player_intelligence_combobox = ttk.Combobox(root, textvariable=player_intelligence_var, values=["Below Average", "Average", "Above Average"])
    player_intelligence_combobox.grid(column=1, row=1, sticky=tk.W)
    player_intelligence_combobox.set("Average")  # Set default value

# Create and place widgets
frame = ttk.Frame(root, padding="10")
frame.grid(column=0, row=0, sticky=(tk.W, tk.E, tk.N, tk.S))

ttk.Label(frame, text="Number of Players:").grid(column=0, row=0, sticky=tk.W)
num_players_entry = ttk.Entry(frame)
num_players_entry.grid(column=1, row=0)

update_button = ttk.Button(frame, text="Update", command=update_gui)
update_button.grid(column=2, row=0)

generate_button = ttk.Button(frame, text="Generate Encounter", command=generate_encounter)
result_label = ttk.Label(frame, text="Selected Monsters:")
difficulty_combobox = ttk.Combobox(frame, values=["Easy", "Medium", "Hard", "Deadly"])
environment_combobox = ttk.Combobox(frame, values=list(environments.keys()))

# Function to update the GUI based on the number of player levels
def update_gui():
    num_players = int(num_players_entry.get())
    
    # Clear existing widgets for Desired Difficulty and Select Environment
    for widget in frame.winfo_children():
        widget.grid_forget()
    
    # Clear existing player level fields
    for entry in player_level_entries:
        entry.grid_forget()
    
    # Create player level fields based on the number of players
    player_level_entries.clear()
    for i in range(num_players):
        ttk.Label(frame, text=f"Player {i + 1} Level:").grid(column=0, row=i + 2, sticky=tk.W)
        entry = ttk.Entry(frame)
        entry.grid(column=1, row=i + 2)
        player_level_entries.append(entry)
    
    # Create and position Desired Difficulty label and combobox
    ttk.Label(frame, text="Desired Difficulty:").grid(column=0, row=num_players + 2, sticky=tk.E)
    difficulty_combobox.grid(column=1, row=num_players + 2, sticky=tk.W)

    # Create and position Select Environment label and combobox
    ttk.Label(frame, text="Select Environment:").grid(column=0, row=num_players + 3, sticky=tk.E)
    environment_combobox.grid(column=1, row=num_players + 3, sticky=tk.W)

    # Adjust the alignment of the buttons and result_label
    generate_button.grid(column=0, row=num_players + 4, columnspan=2, sticky=tk.W)
    result_label.grid(column=0, row=num_players + 5, columnspan=2, sticky=tk.W)

# Function to clear the previous results
def clear_results():
    result_label.config(text="Selected Monsters:")

# Function to clear the previous results
def clear_results():
    result_label.config(text="Selected Monsters:")


# Function to generate an encounter based on player levels, difficulty, and environment
def generate_encounter():
    player_levels = [int(entry.get()) for entry in player_level_entries]
    num_players = len(player_levels)

    if num_players == 0:
        result_label.config(text="No player levels entered.")
        return

    apl = sum(player_levels) / num_players
    desired_difficulty = difficulty_combobox.get()
    selected_environment = environment_combobox.get().capitalize()

    if selected_environment not in environments:
        result_label.config(text="Invalid environment selection.")
        return

    available_monsters = environments[selected_environment]

    difficulty_factors = {
        "Easy": -1,
        "Medium": 0,
        "Hard": 1,
        "Deadly": 2,
    }

    if desired_difficulty not in difficulty_factors:
        result_label.config(text="Invalid difficulty level.")
        return

    cr = max(0, apl + difficulty_factors[desired_difficulty])

    selected_monsters = []
    total_xp = 0

    while total_xp < cr * XP_THRESHOLD:
        available_monsters = [monster for monster in available_monsters if total_xp + monster_info[monster]["cr"] * XP_THRESHOLD <= cr * XP_THRESHOLD]

        if not available_monsters:
            break

        random_monster = random.choice(available_monsters)
        cr_value = monster_info[random_monster]["cr"]

        selected_monsters.append(random_monster)
        total_xp += cr_value * XP_THRESHOLD

    # Clear previous results
    clear_results()

    # Display the selected monsters in the result_label
    if selected_monsters:
        result_label.config(text="Selected Monsters:\n" + "\n".join(selected_monsters))
    else:
        result_label.config(text="No valid monsters found.")

root.mainloop()