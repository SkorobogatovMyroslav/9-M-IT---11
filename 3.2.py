import random
a = [random.randint(1, 100)
 for i in range(5)]
print(a)
b = 0
for x in a:
    if x > 50:
        b += 1
print(b)