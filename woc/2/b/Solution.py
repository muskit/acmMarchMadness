# A = pi*r^2
# pi = A/r^2

# error = abs(est_pi - REFERENCE_PI)
# output: radii of the 5 lowest errors, multiplied together

REFERENCE_PI = 3.141592653589793

# radius: error
lowest_errors = list()

test = '''
    12 415.87439964076873
    16 677.9721431852045
    15 552.1617255431586
    20 1017.6519886367032
    10 257.1309252497689
    13 510.323715360094
    15 479.63127526041376
    10 378.9333879565738
    19 1149.0329697621244
    15 648.5212239205142
)''' 

# for i, line in enumerate(test.splitlines()):
file = open("input.txt")
for i, line in enumerate(file):
    words = line.split() 
    if len(words) < 2: continue # ignore first line

    r, a = int(words[0]), float(words[1])
    est_pi = a/r**2
    pi_diff = abs(REFERENCE_PI - est_pi)

    # update lowest_errors
    if len(lowest_errors) < 5:
        lowest_errors.append((r, pi_diff))
    else:
        for j, _ in enumerate(lowest_errors):
            if pi_diff < lowest_errors[j][1]:
                print(f'{i}: {pi_diff} < {lowest_errors[j][1]}')
                lowest_errors[j] = (r, pi_diff)
                break
    
    # sort list in descending pi-differences 
    lowest_errors.sort(key=lambda x: x[1], reverse=True)
file.close()
print()

# print lowest_errors
for i, elem in enumerate(lowest_errors):
    print(f'{i}: {elem[0]} => {elem[1]}')

# create result
result = lowest_errors[0][0]
for i in range(1, 5):
    result *= lowest_errors[i][0]

print(result)
