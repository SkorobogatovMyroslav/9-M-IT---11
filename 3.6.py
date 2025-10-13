import random
a = [random.randint(1, 100) 
for i in range(5)]
print(a)
for x in a:
    if x % 2 != 0:
        print(x)