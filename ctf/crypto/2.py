data_base = [120, 114, 127, 121, 101, 47, 106, 65, 109, 106, 42, 108, 106, 109, 65, 105, 47, 106, 118, 65, 120, 114, 42, 121, 99]

for k in range(1, 256):
    data = data_base.copy()
    for i, _ in enumerate(data):
        data[i] ^= k
    print("".join([chr(x) for x in data]))