import random
a = [random.randint(1, 100)
 for i in range(5)]
print(a)
for x in a:
    if x % 10 == 0:
        print(x)