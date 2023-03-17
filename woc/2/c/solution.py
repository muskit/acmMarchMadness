from math import pi

# EXAMPLE 1
offices_ex1 = [
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

# EXAMPLE 2
offices = [
    (384, 698),
    (-1230, 868),
    (-1433, 1942),
    (-657, -848),
    (-331, -174),
    (1693, 773),
    (729, 767),
    (-1587, 995),
    (-922, 1101),
    (-882, -1010)
]

# CHALLENGE
offices_chall = [
    (1535, -72),
    (1228, 1471),
    (-415, -144),
    (1052, 1217),
    (1840, -122),
    (895, -934),
    (1047, -324),
    (484, -1570),
    (-332, -564),
    (1818, 1497)
]

def radius(b, c, d):
    temp = c[0]**2 + c[1]**2
    bc = (b[0]**2 + b[1]**2 - temp) / 2
    cd = (temp - d[0]**2 - d[1]**2) / 2
    det = (b[0] - c[0]) * (c[1] - d[1]) - (c[0] - d[0]) * (b[1] - c[1])

    if abs(det) < 1.0e-10:
        return None

    # Center of circle
    cx = (bc*(c[1] - d[1]) - cd*(b[1] - c[1])) / det
    cy = ((b[0] - c[0]) * cd - (c[0] - d[0]) * bc) / det

    radius = ((cx - b[0])**2 + (cy - b[1])**2)**.5

    return radius

#

def main():
    lowest_radius = 999999
    for i in range(0, len(offices)):
        for j in range(i, len(offices)):
            for k in range(j, len(offices)):
                r = radius(offices[i], offices[j], offices[k])
                if r is not None:
                    print(r)
                    lowest_radius = min(r, lowest_radius)

    print()
    print(f'Lowest radius: {lowest_radius}')
    print(f'Circumference: {2*pi*lowest_radius}')




if __name__ == '__main__':
    main()