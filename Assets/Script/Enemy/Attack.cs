using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{

	[Category("Enemy")]
	public class Attack : ActionTask{

        [RequiredField]
        public BBParameter<GameObject> target;

		private UnityEngine.Object bulletPrefab;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			bulletPrefab = Resources.Load("EnemyBullet");
			PoolSystem.Instance.InitPool(bulletPrefab, 32);
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute()
		{
            var bullet = PoolSystem.Instance.GetInstance<GameObject>(bulletPrefab);
            if (bullet != null)
			{
				bullet.GetComponent<EnemyBullet>().InitBullet(agent.transform.position, target.value.transform.position);
			}
            Debug.LogFormat("attack player");
            EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate(){
		}

		//Called when the task is disabled.
		protected override void OnStop(){
			
		}

		//Called when the task is paused.
		protected override void OnPause(){
			
		}
	}
}