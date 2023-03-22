import sys
board = []
rows = ['a', 'b', 'c', 'd', 'e', 'f']
for i in range(0, len(rows)):
    board.append([' '] * 7)

class Stack:
    def __init__(self):
        self._list = []
    
    def __len__(self):
        return len(self._list)    
    
    def push(self, element):
        if len(self._list) <= 6:
            self._list.append(element)
        else:
            return
    
    def peek(self):
        return self._list[-1]

def initStacks():
    S = [ Stack(), Stack(), Stack(), 
         Stack(), Stack(), Stack(), Stack() ]
    return S

def move(stacks, sum):
    Set0 = {'1', '2', '3', '4', '5', '6', '7'}
    print("Which column?")
    pos = str(sys.stdin.readline().strip())
    if pos not in Set0:
        print("Input must be between 1 and 7")
        move(stacks)
    else:
        pos = int(pos)
        if len(stacks[pos-1]) < 6:
            stacks[pos - 1].push("X")
            sum += 6 - len(stacks[pos-1])
            print(sum)
            board[6-len(stacks[pos-1])][pos-1] = stacks[pos-1].peek()
        else:
            print('Column full!')
            move(stacks)
    return stacks, sum

def printBoard():
    rows = ['a','b','c','d','e','f']   
    top = '    1   2   3   4   5   6   7   '
    row = [[n] for n in range(0,7)]
    row[0][0] = 'f | '
    row[1][0] = 'e | '
    row[2][0] = 'd | '
    row[3][0] = 'c | '
    row[4][0] = 'b | '
    row[5][0] = 'a | '
    print('')
    print('  ' + '-'*(len(top)-3))
    for y in range(0,len(rows)):
        for x in range(1,8):
            row[y][0] = row[y][0] + str(board[y][x-1]) + ' | '
        print(row[y][0])
        print('  ' + '-'*((len(row[y][0])-3)))
    print(top)
    print('')

def checkWin(board):
    game = False   

    for y in range(0,6):
        for x in range(3,7):
            if (board[y][x]==board[y][x-1]== board[y][x-2]==board[y][x-3]=="X"):
                    game = True
            else:
                continue   
 
    for x in range(0,7):
        for y in range(3,6):
            if (board[y][x]==board[y-1][x]== board[y-2][x]==board[y-3][x]=="X"):
                    game = True
            else:
                continue

    for x in range(0,4):
        for y in range(0,3):
            if (board[y][x]==board[y+1][x+1]==board[y+2][x+2]==board[y+3][x+3]=="X" or board[y+3][x]==board[y+2][x+1]==board[y+1][x+2]==board[y][x+3]=="X"):
                    game = True
            else:
                continue
    if game:
        print('Game over!')
        if sum == 65:
            flag = open("flag.txt", "r")
            print("Congrats! You actually won! " + flag.read())
            flag.close()
    return game


printBoard()
stacks = initStacks()
sum = 0
game = False
while not game:
    stacks, sum = move(stacks, sum)
    printBoard()
    game = checkWin(board)
