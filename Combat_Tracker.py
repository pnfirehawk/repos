class Combatant:
    def __init__(self, name, initiative, hp):
        self.name = name  # Name of the combatant
        self.initiative = initiative  # Initiative roll
        self.hp = hp  # Hit points
        self.max_hp = hp  # Maximum hit points
        self.damage_taken = 0  # Initialize damage taken to 0

# Create an empty list to store combatants
combatants = []

# Function to add a new combatant to the list
def add_combatant():
    name = input("Enter combatant name: ")
    initiative = int(input("Enter initiative roll: "))
    hp = int(input("Enter hit points: "))
    
    combatant = Combatant(name, initiative, hp)
    combatants.append(combatant)
    
    # Sort combatants by initiative in descending order
    combatants.sort(key=lambda x: x.initiative, reverse=True)

# Function to display the initiative order
def display_initiative_order():
    print("\nInitiative Order:")
    for i, combatant in enumerate(combatants, start=1):
        print(f"{i}. {combatant.name} (Initiative: {combatant.initiative}) (HP: {combatant.hp}) (Damage Taken: {combatant.damage_taken})")

def simulate_combat_round():
    # Add combat logic here
    for i, combatant in enumerate(combatants):
        print(f"\nRound {i + 1}: {combatant.name}'s turn")
        # Add combat actions and logic here
        print(f"{combatant.name}'s HP: {combatant.hp - combatant.damage_taken}/{combatant.max_hp}")
        
        # Option for DM to assign damage
        choice = input(f"Do you want to assign damage to {combatant.name}? (y/n): ").lower()
        if choice == "y":
            damage = int(input(f"Enter the damage amount for {combatant.name}: "))
            combatant.damage_taken += damage
            print(f"{damage} damage assigned to {combatant.name}")
        
        # Check if the combatant is defeated
        if combatant.hp - combatant.damage_taken <= 0:
            print(f"{combatant.name} has been defeated!")
            # You can remove the defeated combatant from the combatants list if needed.

# Main combat loop
while True:
    print("\nCombat Tracker Menu:")
    print("1. Add Combatant")
    print("2. Display Initiative Order")
    print("3. Simulate Combat Round")
    print("4. Exit")
    
    choice = input("Enter your choice: ")
    
    if choice == "1":
        add_combatant()
    elif choice == "2":
        display_initiative_order()
    elif choice == "3":
        simulate_combat_round()
    elif choice == "4":
        break
    else:
        print("Invalid choice. Please try again.")


