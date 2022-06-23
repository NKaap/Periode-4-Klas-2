using UnityEngine;

public class MousePainter : MonoBehaviour{
    public Camera cam;
    public int ratingCounter;
    private float seconds;
    private float colorSeconds; 
    [Space]
    public bool mouseSingleClick;
    [Space]
    public Color paintColor;
    
    public float radius = 1;
    public float strength = 1;
    public float hardness = 1;

    void Update(){
        bool click;
        click = mouseSingleClick ? Input.GetMouseButtonDown(0) : Input.GetMouseButton(0);

        if (click){
            Vector3 position = Input.mousePosition;
            Ray ray = cam.ScreenPointToRay(position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100.0f)){
                Debug.DrawRay(ray.origin, hit.point - ray.origin, Color.red);
                transform.position = hit.point;
                Paintable p = hit.collider.GetComponent<Paintable>();

                if(p != null){
                    PaintManager.instance.paint(p, hit.point, radius, hardness, strength, paintColor);
                    seconds += Time.deltaTime;
                    colorSeconds += Time.deltaTime;
                    if (seconds >= 1f & transform.hasChanged)
                    {
                        seconds = 0f;
                        transform.hasChanged = false;
                        ratingCounter++;
                    }
                    if (colorSeconds >= 0.5f)
                    {
                        paintColor.a += 0.1f;
                        colorSeconds = 0f;
                    }
                }
            }
        }
          if (click == false)
        {
            paintColor.a = 0.5f;
        }
    }
}
