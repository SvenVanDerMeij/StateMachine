using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : BossState
  {
      [SerializeField] GameObject DustCrusher;

      public override void Enter()
      {
          Instantiate(DustCrusher,  transform.position, Quaternion.identity);
      }

      public override void Active()
      {
          GetComponent<BossStateMachine>().SetState(StateId.IdleID);
      }
}