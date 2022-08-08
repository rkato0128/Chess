# Chess
MC Prototype

8/8
- 칸 좌표값 (column, row) Vector2 int 또는 구조체 형식으로 바꾸기
- Moving Direction (-1, 0, 1) Enum 으로
- BoardManager 싱글톤 방식으로 사용 (참고 : https://glikmakesworld.tistory.com/2)
    - 이동 및 이동 체크 로직 체스 말 내부로 이동
- [HideInInspector] 대신 [NonSerialized] 사용