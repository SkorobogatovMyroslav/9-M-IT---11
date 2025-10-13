import random
a = [random.randint(1, 100) 
for i in range(5)]
print(a)
d = 1
for i in range(0, len(a), 2):
    d *= a[i]
print(d)