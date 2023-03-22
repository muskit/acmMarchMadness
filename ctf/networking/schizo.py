import socket

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

s.connect(("137.151.29.178", 1237))

inp = s.recv(256)
print(inp)

while True:
    inp = s.recv(256)
    print(inp)
    r = str(inp)[4:-3]
    print(r)
    s.send(bytearray(f'{r}\n', 'utf-8'))
    
    inp = s.recv(256)
    print(inp)