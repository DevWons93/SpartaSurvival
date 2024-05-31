# SpartaSurvival
 3D Project

 # 개발 환경
* UNITY 2022.3.17fl(LTS)
---
# 기능 구현
1. 필수 구현
   1. 기본 이동 및 점프
   2. 체력바 UI            
   3. 동적 환경 조사
   4. 점프대
      다른 플랫폼도 상속받을 부모클래스 Pad.cs 생성<br/>
      JumpPad.cs 에서 해당 컴포넌트를 가지는 플랫폼은 AddForce로 점프대를 구현<br/>
   6. 아이템 데이터
      UIInventory.cs 의 ThrowItemd에서 AssetDatabase.LoadAssetAtPath를 이용하여 프리펩을 SO 이름으로 생성하도록 구현<br/>
   7. 아이템 사용
      이속/무적 버프 아이템(각각 쿠키, 케이크)를 추가하여 <br/>
      EItemType : Buffable 추가하여 UIInventory.cs의 OnUseButton에서 사용 시 <br/>
      PlayerController.cs에서 플레이어에 적용되도록 구현 <br/>
      
2. 선택 구현 <br/>
   1. 3인칭 시점
      Cinemachine 패키지를 이용하여 1인칭/3인칭 버추얼카메라 생성<br/>
      InputAction에 마우스 휠 입력으로 Zoom 액션 추가하여 시점 변경 기능 추가<br/>
      PlayerController.cs OnZoom에서 3인칭 카메라의 Priority를 입력 값에 따라 조절 (1인칭 10/3인칭 9,11)<br/>
      3인칭에도 아이템 상호작용이 될 수 있게 Interaction.cs에서 ScreenPointToRay에서 방향만 받고<br/>
      플레이어에서 레이를 쏘도록 구현<br/>     
   3. 움직이는 플랫폼 구현
      동선의 시작점과 끝점을 가지는 MovingPoint.cs 클래스 생성 <br/>
      MoivingPad.cs 에서 움직이는 패드의 동선들을 MovingPoint를 인자로 같는 리스트로 관리<br/>
      Start에서 동선 리스트를 큐에 넣어서 다음 동선을 dequeue해 도착지점을 받고 enqueue로 <br/>
      동선이 반복될 수 있게 구현 패드의 움직임은 Vector3.MoveToward로 구현<br/>
      플레이어가 플랫폼 위에 있을 때 위상이 같이 움직일 수 있게 CheckPlayerOnPad에서  <br/>
      플랫폼 위로 BoxCast로 플랫폼 위에 플레이어가 있는지 여부를 확인해 있으면 플레이어를 자식오브젝트로<br/>
      레이 범위 밖이면 해제하는 방법으로 구현<br/>
   5. 레이저 트랩
      트랩 오브젝트를 만들어 하위 오브젝트로 레이의 시작과 끝 포인트를 가질 flag 오브젝트와<br/>
      트랩이 발동 시 데미지를 줄 오브젝트 추가<br/>
      RayTrap.cs 에서 StartFlag와 EndFlag의 Transform 정보를 이용해 CheckRayCatch에서<br/>
      RayCast를 이용해 플레이어가 지나가면 트랩이 발동 되도록 구현<br/>
      FallingTrap.cs 에서는 트랩 발동으로 활성화되는 오브젝트의 리셋과 데미지 로직 구현<br/>
