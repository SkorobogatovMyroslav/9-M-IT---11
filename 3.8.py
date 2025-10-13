import random
a = [random.randint(1, 100) 
for i in range(5)]
print(a)
n = [x for x in a if x % 2 != 0]
if len(n) > 0:
    print(max(n))
else:
    print("Nemae neparnih")