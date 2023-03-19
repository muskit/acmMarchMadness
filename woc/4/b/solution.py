# each segment-char is 3x5; a space separates each segment-char

representations = {
    ('###', '# #', '# #', '# #', '###'): '0',
    (' # ', ' # ', ' # ', ' # ', ' # '): '1',
    ('###', '  #', '###', '#  ', '###'): '2',
    ('###', '  #', '###', '  #', '###'): '3',
    ('# #', '# #', '###', '  #', '  #'): '4',
    ('###', '#  ', '###', '  #', '###'): '5',
    ('###', '#  ', '###', '# #', '###'): '6',
    ('###', '  #', '  #', '  #', '  #'): '7',
    ('###', '# #', '###', '# #', '###'): '8',
    ('###', '# #', '###', '  #', '###'): '9',
    ('   ', '   ', '   ', '   ', ' # '): '.',
    ('   ', '   ', '###', '   ', '   '): '-',
    ('   ', ' # ', '###', ' # ', '   '): '+',
    ('   ', '# #', ' # ', '# #', '   '): '*',
}

expressions = []
with open('input.txt') as f:
    count = int(f.readline().strip())

    # process each line of segment char
    for i in range(0, count):
        # get segment line
        segment_line = []
        for _ in range(0, 5):
            segment_line.append(f.readline().rstrip())
        
        # -- print segment line
        # for l in segment_line:
        #     print(l)
        # print()
        
        # process each segment char of line
        i = 0
        current_expression = ''
        while i < len(segment_line[0]):
            t = (segment_line[0][i:i+3].ljust(3),
                 segment_line[1][i:i+3].ljust(3),
                 segment_line[2][i:i+3].ljust(3),
                 segment_line[3][i:i+3].ljust(3),
                 segment_line[4][i:i+3].ljust(3))
            
            # -- print segment character
            # print('---------')
            # for l in t:
            #     print(f'({l})')

            char = representations[t]
            current_expression += char

            # different shift for 1-wide characters
            if char in ('1', '.'):
                i += 4
            else:
                i += 5
        
        expressions.append(current_expression)
        f.readline()


# process each saved expression
sum = 0
for exp in expressions:
    ans = eval(exp)
    sum += ans
    is_negative = sum < 0
    sum %= 10**7
    if is_negative: sum * -1

print("{:0.2f}".format(sum))