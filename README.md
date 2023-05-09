# 유니티 뉴 인풋시스템 커스터마이징
 Unity New Input System Customize
 
 Legacy Input Class와 사용방식이 유사하도록
 New Input system 의 사용방식을 커스텀함.
 
 baseActionMap 을 기준으로 Action Name 을 인자로 받아 전체 Action Map 에서 찾는다. -> ActionByIndex 로 Dictionary 로 존재하므로 속도 느리지 않음.
 
 사용 측면에서 자신의 원하는 Action Map 만 Map Name을 인자로 받아 Enable/Disable 함. -> 모든 맵의 체크를 하지 않기 위해
