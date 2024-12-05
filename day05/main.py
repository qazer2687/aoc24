from collections import defaultdict

def parse_input(file_path):
    with open(file_path, 'r') as file:
        input_data = file.read()
    
    # split rules and updates
    rules_section, updates_section = input_data.strip().split("\n\n")
    # convert rules into a list of tuples
    rules = [tuple(map(int, line.split('|'))) for line in rules_section.splitlines()]
    # convert updates into a list of lists
    updates = [list(map(int, line.split(','))) for line in updates_section.splitlines()]
    return rules, updates

def build_graph(rules):
    graph = defaultdict(list)
    for x, y in rules:
        graph[x].append(y)
    return graph

def is_valid_order(update, graph):
    # iterate through each rule and check against update
    position = {page: idx for idx, page in enumerate(update)}
    for x in update:
        for y in graph[x]:
            if y in position and position[x] > position[y]:
                return False
    return True

def find_middle(update):
    return update[len(update) // 2]

def calculate_sum_of_middle_pages(file_path):
    rules, updates = parse_input(file_path)
    graph = build_graph(rules)
    
    total = 0
    for update in updates:
        if is_valid_order(update, graph):
            total += find_middle(update)
    return total

file_path = './input'

# part 1
print(calculate_sum_of_middle_pages(file_path))

