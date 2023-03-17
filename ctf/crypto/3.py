data = [102, 10, 13, 6, 28, 74, 69, 43, 108, 93, 13, 17, 11, 9, 4, 7, 44, 110, 69, 7, 64, 95, 10, 27]

for i in range(1, len(data)):
    data[i] ^= data[i-1]
print("".join([chr(x) for x in data]))