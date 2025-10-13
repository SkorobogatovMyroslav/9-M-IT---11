import random
a = [random.randint(1, 100) 
for i in range(5)]
print(a)
s = 0
for x in a:
    s += x**3
print(s)