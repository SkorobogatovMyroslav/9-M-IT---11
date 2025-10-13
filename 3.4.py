import random
a = [random.randint(1, 100) 
for i in range(5)]
print(a)
for i in range(len(a)):
    if a[i] < 20:
        a[i] = 0
print(a)