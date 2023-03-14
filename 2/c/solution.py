from math import sqrt, pi

# TEST
offices = [
    (1579, 1892),
    (-1784, -796),
    (46, -101),
    (1815, -1236),
    (529, -799),
    (1365, -870),
    (1931, -1369),
    (341, 610),
    (-1572, -1599),
    (425, 421)
]

# offices = [
#     (1535, -72),
#     (1228, 1471),
#     (-415, -144),
#     (1052, 1217),
#     (1840, -122),
#     (895, -934),
#     (1047, -324),
#     (484, -1570),
#     (-332, -564),
#     (1818, 1497)
# ]

def radius(xy):
    return sqrt(xy[0]**2 + xy[1]**2)

#

lowest = radius(offices[0])
for i, elem in enumerate(offices):
    r = radius(elem)
    lowest = r if r < lowest else lowest

print(pi*2*lowest)