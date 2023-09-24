import random

# Define dictionaries of possible character names by race
race_names = {
    "Human": {
        "Male": ["John", "Michael", "David", "William", "James"],
        "Female": ["Mary", "Jennifer", "Linda", "Patricia", "Elizabeth"],
    },
    "Elf": {
        "Male": ["Legolas", "Elrond", "Thranduil", "Galadriel", "Celeborn"],
        "Female": ["Arwen", "Lúthien", "Galadriel", "Aranel", "Elanor"],
    },
    "Dwarf": {
        "Male": ["Thorin", "Gimli", "Balin", "Dwalin", "Oin"],
        "Female": ["Dis", "Thorina", "Dori", "Nori", "Ori"],
    },
    "Halfling": {
        "Male": ["Frodo", "Samwise", "Merry", "Pippin", "Bilbo"],
        "Female": ["Rosie", "Daisy", "Primula", "Belladonna", "Camellia"],
    },
    "Dragonborn": {
        "Male": ["Drake", "Singe", "Ryzeek", "Vraxim", "Azurath"],
        "Female": ["Valeria", "Zephyra", "Kazara", "Sarkanna", "Vaelin"],
    },
    "Gnome": {
        "Male": ["Fizzlebang", "Tinkerbell", "Glimmergrin", "Babblebrook", "Rumblebelly"],
        "Female": ["Glimmertop", "Dazzleflare", "Babblebrook", "Sparklewhistle", "Blinkerbop"],
    },
    "Half-Orc": {
        "Male": ["Gruk", "Thruk", "Durnak", "Krul", "Gorn"],
        "Female": ["Lurgu", "Tharag", "Brukah", "Kurga", "Hraga"],
    },
    "Tiefling": {
        "Male": ["Damien", "Lucien", "Mephistopheles", "Asmodeus", "Bael"],
        "Female": ["Lilith", "Morrigan", "Astrid", "Lethia", "Succubus"],
    },
}
    # Add more races and names as needed


# Define lists of possible character traits and options
races = ["Human", "Elf", "Dwarf", "Halfling", "Dragonborn", "Gnome", "Half-Orc", "Tiefling"]
classes = ["Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard"]
backgrounds = ["Acolyte", "Charlatan", "Criminal", "Entertainer", "Folk Hero", "Guild Artisan", "Hermit", "Noble", "Outlander", "Sage", "Sailor", "Soldier", "Urchin"]

# Define class skills
class_skills_options = {
    "Barbarian": ["Animal Handling", "Athletics", "Intimidation", "Nature", "Perception", "Survival"],
    "Bard": ["Acrobatics", "Athletics", "Deception", "Insight", "Intimidation", "Investigation", "Perception", "Performance", "Persuasion", "Sleight of Hand", "Stealth", "History"],
    "Cleric": ["History", "Insight", "Medicine", "Persuasion", "Religion"],
    "Druid": ["Arcana", "Animal Handling", "Insight", "Medicine", "Nature", "Perception", "Religion", "Survival"],
    "Fighter": ["Acrobatics", "Animal Handling", "Athletics", "History", "Insight", "Perception", "Survival"],
    "Monk": ["Acrobatics", "Athletics", "History", "Insight", "Religion", "Stealth"],
    "Paladin": ["Athletics", "Insight", "Intimidation", "Medicine", "Persuasion", "Religion"],
    "Ranger": ["Animal Handling", "Athletics", "Insight", "Investigation", "Nature", "Perception", "Stealth", "Survival"],
    "Rogue": ["Acrobatics", "Athletics", "Deception", "Insight", "Intimidation", "Investigation", "Perception", "Performance", "Persuasion", "Sleight of Hand", "Stealth"],
    "Sorcerer": ["Arcana", "Deception", "Insight", "Intimidation", "Persuasion", "Religion"],
    "Warlock": ["Arcana", "Deception", "History", "Intimidation", "Investigation", "Nature", "Religion"],
    "Wizard": ["Arcana", "History", "Insight", "Investigation", "Medicine", "Religion"],
}

# Define background skill options
background_skills_options = {
    "Acolyte": ["Insight", "Religion"],
    "Charlatan": ["Deception", "Sleight of Hand"],
    "Criminal": ["Deception", "Stealth"],
    "Entertainer": ["Acrobatics", "Performance"],
    "Folk Hero": ["Animal Handling", "Survival"],
    "Guild Artisan": ["Insight", "Persuasion"],
    "Hermit": ["Medicine", "Religion"],
    "Noble": ["History", "Persuasion"],
    "Outlander": ["Athletics", "Survival"],
    "Sage": ["Arcana", "History"],
    "Sailor": ["Athletics", "Perception"],
    "Soldier": ["Athletics", "Intimidation"],
    "Urchin": ["Sleight of Hand", "Stealth"],
}

# Prompt the user for the character's level
while True:
    try:
        character_level = int(input("Enter the character's level (1-20): "))
        if 1 <= character_level <= 20:
            break
        else:
            print("Please enter a level between 1 and 20.")
    except ValueError:
        print("Invalid input. Please enter a valid level.")

# Generate ability scores (assuming 4d6 drop lowest method)
def roll_ability_scores():
    ability_scores = []
    for _ in range(6):
        rolls = [random.randint(1, 6) for _ in range(4)]
        rolls.remove(min(rolls))
        ability_scores.append(sum(rolls))
    return ability_scores

random_ability_scores = roll_ability_scores()

# Define feats, including those with stat choices (customize as needed)
feats = [
    {"name": "Resilient", "description": "Choose one ability score. You gain proficiency in saving throws using that ability score."},
    {"name": "Tough", "description": "Increase your Constitution score by 1, up to a maximum of 20."},
    {"name": "Dual Wielder", "description": "Increase your Strength or Dexterity score by 1, up to a maximum of 20."},
    # Add more feats here, including third-party feats
    # ...
    # Regular feats without stat choices
    {"name": "Alert"}, {"name": "Athlete"}, {"name": "Actor"}, {"name": "Charger"}, {"name": "Crossbow Expert"}, {"name": "Defensive Duelist"}, {"name": "Dungeon Delver"}
    # ...
]

# Define class subclass options
class_subclass_options = {
    "Barbarian": ["Path of the Berserker", "Path of the Totem Warrior", "Path of the Wild Soul"],
    "Bard": ["College of Lore", "College of Valor", "College of Eloquence"],
    "Cleric": ["Knowledge Domain", "Life Domain", "Trickery Domain"],
    "Druid": ["Circle of the Land", "Circle of the Moon", "Circle of the Spores"],
    "Fighter": ["Battle Master", "Champion", "Eldritch Knight"],
    "Monk": ["Way of the Open Hand", "Way of Shadow", "Way of the Four Elements"],
    "Paladin": ["Oath of Devotion", "Oath of the Ancients", "Oath of Vengeance"],
    "Ranger": ["Hunter", "Beast Master", "Horizon Walker"],
    "Rogue": ["Thief", "Assassin", "Arcane Trickster"],
    "Sorcerer": ["Draconic Bloodline", "Wild Magic", "Storm Sorcery"],
    "Warlock": ["The Archfey", "The Fiend", "The Great Old One"],
    "Wizard": ["School of Abjuration", "School of Conjuration", "School of Divination"],
}

# Generate character subclass based on character class and level
def generate_subclass(character_class, character_level):
    if character_level >= 3 and character_class in class_subclass_options:
        return random.choice(class_subclass_options[character_class])
    return "No subclass chosen"

# Define additional feats to be granted at specific levels
additional_feats_by_level = {
    4: 1,  # Number of additional feats at level 4
    8: 1,  # Number of additional feats at level 8
    12: 1,  # Number of additional feats at level 12
    16: 1,  # Number of additional feats at level 16
    20: 1,  # Number of additional feats at level 20
}

# Calculate the total number of additional feats for the character's level
total_additional_feats = 0
for level, num_feats in additional_feats_by_level.items():
    if character_level >= level:
        total_additional_feats += num_feats

# Randomly select additional feats based on the total_additional_feats
additional_feats = []

# Create a set to keep track of selected feats
selected_feats = set()

while len(additional_feats) < total_additional_feats:
    # Randomly select a feat
    additional_feat = random.choice(feats)
    feat_name = additional_feat['name'] if isinstance(additional_feat, dict) else additional_feat

    # Check if the feat has not been selected before, and if so, add it to the list of additional feats
    if feat_name not in selected_feats:
        additional_feats.append(additional_feat)
        selected_feats.add(feat_name)


# Randomly select a race, class, and background
random_race = random.choice(list(race_names.keys()))
random_gender = random.choice(list(race_names[random_race].keys()))
random_class = random.choice(classes)
random_background = random.choice(backgrounds)

# Randomly select a name based on the chosen race and gender
random_name = random.choice(race_names[random_race][random_gender])


# Select class skills based on character class
if random_class in class_skills_options:
    class_skills = random.sample(class_skills_options[random_class], 2)  # Randomly select 2 class skills
else:
    class_skills = []

# Select background skills based on character background
if random_background in background_skills_options:
    background_skills = background_skills_options[random_background]  # Use the predefined skills for the background
else:
    background_skills = []

# Ensure class and background skills do not overlap
for skill in background_skills:
    if skill in class_skills:
        # If a background skill matches a class skill, replace it with a non-class skill
        class_skills.remove(skill)
        remaining_skills = [s for s in class_skills_options[random_class] if s not in class_skills]
        non_class_skill = random.choice(remaining_skills)
        class_skills.append(non_class_skill)

# Combine the selected skills
selected_skills = class_skills + background_skills

# Generate character subclass
random_subclass = generate_subclass(random_class, character_level)

# Print the randomly generated character
print("\nRandomly Generated D&D 5E Character:")
print(f"Randomly Generated Name: {random_name}")
print(f"Level: {character_level}")
print(f"Race: {random_race}")
print(f"Class: {random_class}")
print(f"Subclass: {random_subclass}")
print(f"Background: {random_background}")
print("Ability Scores:")
for i, score in enumerate(random_ability_scores):
    print(f"   Ability {i + 1}: {score}")
print(f"Feats: {', '.join(feat['name'] for feat in additional_feats)}")
print(f"Skills: {', '.join(selected_skills)}")


# Create a text file with the character's information
with open(f"D:\My D&D characters\{random_name}_character.txt", "w") as character_file:
    character_file.write("Randomly Generated D&D 5E Character:\n")
    character_file.write(f"Name: {random_name}\n")
    character_file.write(f"Level: {character_level}\n")
    character_file.write(f"Race: {random_race}\n")
    character_file.write(f"Class: {random_class}\n")
    character_file.write(f"Subclass: {random_subclass}\n")
    character_file.write(f"Background: {random_background}\n")
    character_file.write("Ability Scores:\n")
    for i, score in enumerate(random_ability_scores):
        character_file.write(f"   Ability {i + 1}: {score}\n")
    character_file.write(f"Feats: {', '.join(feat['name'] for feat in additional_feats)}\n")
    character_file.write(f"Skills: {', '.join(selected_skills)}\n")

print(f"Character information has been saved to {random_name}_{random_class}_{character_level}_character.txt")

