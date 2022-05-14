# Infinite-Ground
Infinite Ground / Endless Ground / Pooling Ground

Preview:
https://youtu.be/A7DYiCROVRk

How to:
1. Create Gameobject > add component Infinite Ground
![image](https://user-images.githubusercontent.com/14213507/168417607-b7d0fa00-3382-4527-8a98-440ac6964187.png)

2. Assign Target (player), Ground Prefab, and Ground Size (size in world scale)
![image](https://user-images.githubusercontent.com/14213507/168417548-f2b95329-96a5-4efa-bf47-de48f1c7e4f8.png)

How does it works?
1. It spawn ground prefab in 9 places
![image](https://user-images.githubusercontent.com/14213507/168417802-3365f852-5c91-4a57-81ff-7aaa22c8059e.png)
2. InfiniteGround.cs will detect and reposition the 'Spawned Ground' that appears further from the target
