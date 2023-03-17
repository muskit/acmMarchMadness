data = [51, 57, 52, 50, 46, 45, 101, 39, 10, 55, 101, 33, 61, 10, 34, 97, 44, 38, 40]

for i, _ in enumerate(data):
    data[i] ^= 85

print("".join([chr(x) for x in data]))