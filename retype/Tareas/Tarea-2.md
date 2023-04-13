![Screenshot 2023-03-22 213927](https://user-images.githubusercontent.com/75856980/227072791-48bc566f-75a9-4742-a01b-71ff419504b5.jpg)

Empece agruegando los objetos y despues con el script.
aqui cree el movimiento usando el Input.GetAxis
```ruby
{
    public CharacterController controller;

    public float speed = 6f;

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(0f, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }

    }
```
![Screenshot 2023-03-22 222944](https://user-images.githubusercontent.com/75856980/227075826-b83e639d-6848-489e-8898-7addd3f10c8e.jpg)
Aqui intente crear la rotacion que no funciono como queria y rotaba el objeto noma

```ruby
    public float speed = 6f;
    public float sensitivity = 8f;
    public float rotateSpeed = 8f;
    private bool rotateLeft = false;
    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(0f, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }
        if (Input.mousePosition.x <= Screen.width / 2)
        {
            rotateLeft = true;
        }
        else
        {
            rotateLeft = false;
        }
        if (Input.GetMouseButton(0))
        {
            float rotateAmount = sensitivity * Time.deltaTime;
            if (rotateLeft)
            {
                rotateAmount *= -rotateSpeed;
            }
            else
            {
                rotateAmount *= rotateSpeed;
            }

            Vector3 rotation = new Vector3(0f, rotateAmount, 0f);
            transform.eulerAngles += rotation;
        }
    }
```
Despues me di cuenta que esto no servia y busque por una forma mas corto y que sirva.

Empece crando una vector3 nuevo rotatedDirection que usa la rotacion y la variable direccion que cree anteriormente para el movimiento despues cree un variable para rotar de forma horizontal con el mouse
```ruby
{
    public CharacterController controller;

    public float speed = 6f;
    public float sensitivity = 10f;

    void Update()
    {
        //Movimiento W y S
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(0f, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            Vector3 rotatedDirection = transform.rotation * direction;
            controller.Move(rotatedDirection * speed * Time.deltaTime);
        }
        //Rotation
        if (Input.GetMouseButton(0))
        {
           float rotateHorizontal = Input.GetAxis("Mouse X");
           Vector3 rotation = new Vector3(0f, rotateHorizontal, 0f) * sensitivity;
           transform.Rotate(rotation, Space.World);
           
        }
    }
```

[!embed](https://user-images.githubusercontent.com/75856980/227369357-db29342a-a8ca-4f7c-b014-07cdb618c773.mp4)



