![image](https://user-images.githubusercontent.com/75856980/229263647-dca2c68d-9f35-45a1-82cc-6f91e856d4ff.png)
consegui un modelo de lechonk y un tocino mi plan es hacer que aumente su tamaño cada vez que haga colicion con el tocino.

**Mejora de movimiento**
***

Una vez ya pensado lo que queria hacer agruegue los movimientos a y d y un salto al script de la Tarea 2
```ruby
{
    //Movimiento W, A, S, D
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");
    Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

    if (direction.magnitude >= 0.1f)
    {
        Vector3 rotatedDirection = transform.rotation * direction;
        controller.Move(rotatedDirection * speed * Time.deltaTime);
    }

    //Jump
    if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    //Apply gravity
    velocity.y += gravity * Time.deltaTime;
    controller.Move(velocity * Time.deltaTime);

    //Rotation
    if (Input.GetMouseButton(0))
    {
        float rotateHorizontal = Input.GetAxis("Mouse X");
        Vector3 rotation = new Vector3(0f, rotateHorizontal, 0f) * sensitivity;
        transform.Rotate(rotation, Space.World);
    }
 }
```
en //Jump estoy haciendo que ejecute el codigo cuando se encruentre encima un superficie y con el espacio apretado
el velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); calcula la velocidad vertical necesaria utilizando la altura y la gravedad
en //Apply gravity agruegue gravedad que se ultilisa en el codigo para el salto y en el controlador

**La colision y cambio de tamaño**
***

Agrugue box collider al tocino y a lechonk
empece especificando para que cuando choque con el tocino se ejecuta el codigo
```ruby
void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.name == "Bacon_Uncooked")
    {
        // Codigo
    }
}
```
aqui utilize el transform para incrementar el tamaño de lechonk en todo los axis
```ruby
void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.name == "Bacon_Uncooked")
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
    }
}
```
esto no funciono entonces agruegue un debug.log para ver si la collusion ocuria
```
Debug.Log("Collided with " + collision.gameObject.name);
```
quitando el is triger lo arreglo
la rocka al lado del tocino es el mismo tamaño que lechonk

[!embed](https://user-images.githubusercontent.com/75856980/229266541-6205db2b-03f6-4e07-8a60-4b4e04d18b52.mp4)


