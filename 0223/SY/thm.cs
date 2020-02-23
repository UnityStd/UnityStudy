//20.02.23

/*


 @ Trasform Position (ball)
 float startingPoint;
 start -> startingPoint - transform.position.z;
 update -> float distance;
    distance = trasnform.position.z-startingPoint;
    Debug.Log(distance);

 @ Trasform 바꾸기 (obstacle)
 update -> float delta = -0.1f;
    float newXPosition = trasform.position.x+delta;
    trasnform.position = new Vector3(newXPosition, 2, -1);
    if(transform.position.x < -3.5)
    {
        delta = 0.1f;
    }
    else if(transform.position.x > 3.5)
    {
        delta = -0.1f;
    }
--> x축에서 -3.5~3.5 위치만큼 움직임

@ GetComponent (ball)
start -> Rigidbody myRigidbody = GetComponent<Rigidbody>();
    Debug.Lof("UseGravity?: " + myRigidbody.UseGravity;
--> 중력을 사용하는가?
    SphereCollider myCollider;
    myCollider=GetComponent<SphereCollider>();
    myCollider.radius = myCollider.radius +0.01f;
--> 콜라이더 반지름이 점점 커짐

@ 카메라 움직이기 (Camerawork)
GameObject ball;
start -> ball = GameObject.Find("Ball");
update -> transform.position = new Vector3(0, ball.transform.position.y+3, ball.transform.position.z-14);
-->카메라가 공을 따라감

@ 사용자로부터 입력 받기 (Ground)
update -> float zRotation = transform.localEulerAngles.z;
    zRotation = zRotation - Input.GetAxis("Horizontal");
    transform.localEulerAngles = new Vector3(10, 0, zRotation);
--> 오른쪽 누르면 오른쪽으로 돌아가고 왼쪽을 누르면 왼쪽으로 돌아감(키보드)

@ 키 입력 받기 (ball)
update -> if(Input.GetKeyDown(KetCode.Space))
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up*300);
    }
--> 스페이스바 누르면 튀어오름

@ 마우스 입력 받기 (Ground)
update -> If(Input.touchCount >0 || Input.GetMouseButton(0))
    {
        if(Input.mousePosition.x < Screem.width /2)
        {
            transform.localEulerAngles = new Vector3(10, 0, transform.localEulerAngles.z + 1.0f);
        }   //왼쪽 클릭 -> 왼쪽으로 돌리려면 각도 증가
        else
        {
            transform.localEulerAngles = new Vector3(10, 0, transform.localEulerAngles.z - 1.0f);
        }   //오른쪽 클릭 -> 오른쪽으로 돌리려면 각도 감소
    }
--> 마우스 오른쪽 누르면 오른쪽으로 돌아가고 왼쪽을 누르면 왼쪽으로 돌아감
 
@ Local Position (Obstacle)
update -> float delta = -0.1f;
    float newXPosition = transform.localPosition.x+delta;
    transform.localPosition = new Vector3(newXPosition, transform.localPosition.y, transform.localPosition.z);
    if(transform.localPosition.x < -3.5)
    {
        delta = 0.1f;
    }
    else if(transform.localPosition.x > 3.5)
    {
        delta = -0.1f;
    }
--> 스테이지(ground)가 돌아갈 때 장애물(Obstacle)도 붙어서 같이 돌아감

@ OnCollisionEnter (Obstacle)
    void OnCollisionEnter(Collision collision)
    {
        Vector3 direction = transform.position - collision.gameObject.transform.position;
        direction = direction.normalized*1000;
        collision.gameObject.GetComponent<Rigidbody>().AddForce(direction);
    }
--> 공(Ball)이 장애물(Obstacle)에 부딪치면 튕겨나감

@ OnTriggerEnter (FailZone)   //(Coin)
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "Ball")
        {
            Application.LoadLevel("Practice");  //Destroy(gameObject);
        }
    }
--> Ball에 충돌하면 "Practice" 프로젝트를 재시작  //충돌하면 사라짐

@ Tag (Camerawork)
GameObject ball;
start -> ball = GameObject.Find("Ball");
    GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
    Debug,Log(coins[0].name);
(RedCoin)
void OnTriggerEnter(Collider col)
{
    if (col.gameObject.name == "Ball")
    {
        DestroyObstacles();
        Destroy(gameObject);
    }
}
void DestroyObstacles()
{
    GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
    for (int i = 0; i < obstacles.Length; i++)
    {
        Destroy(obstacles[i]);
    }
}
--> "Obstacle" 태그 지정된 것들이 RedCoin과 공이 충돌하면 사라짐(피버모드)

@ GameManager
void RestartGame()
{
    Application.LoadLevel("Practice");
}
(FailZone)
void OnTriggerEnter(Collider collider)
{
    if(collider.gameObject.name == "Ball")
    {
        GameObject.Find("GameManager").SendMessage("RestartGame"); 
    }
}
--> 공이 FailZone에 충돌하면 재시작
(RedCoin) 에 있는
void DestroyObstacles()
{
    GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
    for (int i = 0; i < obstacles.Length; i++)
    {
        Destroy(obstacles[i]);
    }
}
(를 GameManager로 이동 후 
void RedCoinStart()
{
    DestroyObstacles();
}
추가)
(RedCoin)
void OnTriggerEnter(Collider col)
{
    if (col.gameObject.name == "Ball")
    {
        GameObject.Find("GameManager").SendMessage("RedCoinStart");
        Destroy(gameObject);
    }
}
--> 공이 RedCoin에 충돌하면 장애물들이 모두 파괴됨(피버모드)

@ 코인 갯수 세기 
(GameManager)
int coinCount = 0;
void GetCoin()
{
    coinCount++;
    Debug.Log("동전: " + coinCount);
}
(Coin)
void OnTriggerEnter(Collider collider)
{
    if(collider.gameObject.name == "Ball")
    {
        GameObject.Find("GameManager").SendMessage("GetCoin");
        Destroy(gameObject);
    }
}
--> 공이 Coin에 충돌할 때마다 동전의 갯수(coinCount)가 올라감

@ GetComponent 같은 표현 (Ball)
//GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
Rigidbody ballRigid;
ballRigid = gameObject.GetComponent<Rigidbody>();
ballRigid.AddForce(Vector3.up * 300);
--> 스페이스바 누르면 공이 튀어오름 (Debug.Log(ballRigid.mass); -> 질량

@ Public (FailZone)
//GameObject.Find("GameManager").SendMessage("RestartGame"); //맨밑 두줄이랑 같음
//GameObject gm = GameObject.Find("GameManager");  //2,3번째 줄이 4번째 줄과 같음
//GameManager gmComponent = gm.GetComponent<GameManager>();
GameManager gmComponent = GameObject.Find("GameManager").GetComponent<GameManager>();
gmComponent.RestartGame();   //사용하려면 GameManager에 있는 void RestartGame()앞에 public 붙어야 함
--> FailZone에 공이 충돌하면 재시작
(FailZone)
update ->  GameManager gmComponent = GameObject.Find("GameManager").GetComponent<GameManager>();
    Debug.Log(gmComponent.coinCount);  //사용하려면 GameManager에 있는 int coinCount = 0; 앞에 public 을 붙여야 함
--> 코인 갯수 세기

@ Inspector 와 Public 변수 (Camerawork)
public GameObject ball; 로 앞에 public 을 붙이면 start 안에 ball=GameObject.Find("Ball"); 안써도 됨
--> Main Camera -> Camerawork 인스펙터 창에 Ball을 넣는 칸이 생김

@ UI 그리기 (GameManager)
GameObject-> UI-> Text-> 0
맨위 -> using UnityEngine.UI;
class -> public int coinCount = 0;
    public Text coinText;
    void GetCoin()
    {
        coinCount++;
        coinText.text = coinCount + "개";
        Debug.Log("동전: " + coinCount);
    }  -> GameManager 인스펙터의 CoinText 칸에 Text 넣기
--> 공이 Coin에 충돌할 때마다 Text의 숫자가 올라감

@ 돌던지기 (Stone)
class -> Vector3 target;
start -> target = GameObject.Find("Ball").transform.position;
update ->  transform.position = Vector3.MoveTowards(transform.position, target, 0.1f);
    transform.Rotate(new Vector3(0, 0, 5));
--> 돌이 회전하며 공의 방향으로 날아옴
Update ->  void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Ball")
        {
            GameManager gmComponent = GameObject.Find("GameManager").GetComponent<GameManager>();
            gmComponent.RestartGame();
        }
    }  -> Stone-> Box Collider-> Is Trigger 체크
--> 돌(Stone)이 공(Ball)에 충돌하면 게임 재시작

@ Time.delta (Shooter)  <-Obstacle 코드 복붙 +
update 위(바깥) -> float timeCount=0;
class 밑 -> public GameObject stone;  //프리펩만들고 Stone에 넣기
update{} -> timeCount += Time.deltaTime;
        if (timeCount > 3)
        {
            Instantiate(stone, transform.position, Quaternion.identity);
            timeCount = 0;
        }
--> Shooter에서 3초마다 공(Ball)을 향해 돌(Stone)이 회전하며 날아옴

@ 상속
(Shooter)
Shooter의 public class Shooter : Obstacle {  이후 Obstacle에 있는 내용 삭제
--> Shooter가 Obstcle을 상속받는 자식클래스이다
---> update에 있는 돌을 3초마다 던지는 기능이 Obstacle의 update를 덮어쓰고 있어서 동작이 안됨 -> 오버라이딩
(Obstacle)
protected void Update() {
--> 자식 클래스에게만 사용 가능하게 허락
(Shooter)
update -> base.Update(); 추가
--> Obstacle의 Update를 호출
---> Shooter가 움직이면서 3초마다 Stone을 돌아가며 Ball을 향해 발사


 */
