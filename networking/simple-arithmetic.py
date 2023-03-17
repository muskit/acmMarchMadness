import socket

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

s.connect(("137.151.29.178", 1236))

inp = s.recv(256)
print(inp)
nums = s.recv(256)
print(nums)

nums = str(nums).split('\\n')
print(nums)

print('sending sum...')
s.send(bytearray(f'{int(nums[1]) + int(nums[2])}\n', 'utf-8'))
print(s.recv(2048))

while True:
    inp = s.recv(256)
    print(inp)
    nums = str(inp).split('\\n')

    print('sending sum...')
    s.send(bytearray(f'{int(nums[2]) + int(nums[3])}\n', 'utf-8'))
    print(s.recv(2048))