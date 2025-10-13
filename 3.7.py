import random
a = [random.randint(1, 100) 
for i in range(5)]
print(a)
k = 0
for x in a:
    if 30 <= x <= 70:
        k += 1
print(k)