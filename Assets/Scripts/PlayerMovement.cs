using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public GameObject hero;
	public Rigidbody2D heroRigidBody;
	public float moveSpeed;
	public float rollSpeed;
	public string bulletTag;
  public Camera gameCamera;

	public float parryRadius;
	public float parryAngle;

	private bool isPlayerInParrySuccess;
	public float parrySuccessInvencibilityTime;
	private float parrySuccessIvencibilityCounter;
	private bool isPlayerInParryFail;
	public float parryFailInvencibilityTime;
	private float parryFailIvencibilityCounter;

	public bool isPlayerInvulnerable;

	public bool isPlayerInputsDisabled;
	public SpriteRenderer heroSprite;

	private bool isPlayerInRoll;
	public float rollTime;
	private float rollCounter;

	private Vector3 rollStartPos;
	private Vector3 rollEndPos;

	public Animator heroAnimator;
	
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.hero.transform.position, this.parryRadius);
		Quaternion heroRotation = this.hero.transform.rotation;
		Vector3 radiusPt = this.hero.transform.position;
		radiusPt.x += this.parryRadius;
		radiusPt -= this.hero.transform.position;
        Gizmos.DrawLine(this.hero.transform.position, Quaternion.AngleAxis(this.parryAngle, Vector3.forward) * radiusPt + this.hero.transform.position);
		Gizmos.DrawLine(this.hero.transform.position, Quaternion.AngleAxis(this.parryAngle, -1.0f * Vector3.forward) * radiusPt + this.hero.transform.position);
    }

	// Update is called once per frame
	void Update () {
		// Look at mouse position
		if(!this.isPlayerInputsDisabled) {
			var v3 = Input.mousePosition;
			v3.z = 0.0f;
			v3 = gameCamera.ScreenToWorldPoint(v3);
			v3 -= this.hero.transform.position;

			float angle = Mathf.Atan2(v3.y, v3.x) * Mathf.Rad2Deg;
			//Debug.Log(angle);
			this.hero.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}

		//Dash
		if(!this.isPlayerInputsDisabled) {
			
			float h = Input.GetAxisRaw("Horizontal");
			float v = Input.GetAxisRaw("Vertical");

			if(Input.GetKeyDown("space"))
			{
				this.rollCounter = 0.0f;
				this.isPlayerInRoll = true;
				this.isPlayerInputsDisabled = true;
				this.isPlayerInvulnerable = true;
				Color c = this.heroSprite.color;
				c.r = 0.5f;
				c.g = 0.5f;
				this.heroSprite.color = c;
				this.rollStartPos = this.hero.transform.position;
				Vector3 tempVect = new Vector3(h, v, 0);
				if(tempVect.magnitude < Mathf.Epsilon) {
					var v3 = Input.mousePosition;
					v3.z = 0.0f;
					v3 = gameCamera.ScreenToWorldPoint(v3);
					v3.z = this.hero.transform.position.z;
					v3 -= this.hero.transform.position;
					tempVect = v3.normalized;
				}
				this.rollEndPos = tempVect.normalized * this.rollSpeed * this.rollTime;
				this.rollEndPos += this.hero.transform.position;
			}
		}

		// Move with wasd
		if(!this.isPlayerInputsDisabled) {
			float h = Input.GetAxisRaw("Horizontal");
			float v = Input.GetAxisRaw("Vertical");
			Vector3 tempVect = new Vector3(h, v, 0);
			if(tempVect.magnitude < Mathf.Epsilon) {
				this.heroAnimator.SetBool("IsWalking", false);
			} else {
				this.heroAnimator.SetBool("IsWalking", true);
			}
			tempVect = tempVect.normalized * this.moveSpeed * Time.deltaTime;
			this.heroRigidBody.MovePosition(this.heroRigidBody.transform.position + tempVect);
		} else {
			this.heroAnimator.SetBool("IsWalking", false);			
		}

		if(this.isPlayerInRoll) {
			this.rollCounter += Time.deltaTime;
			float t = (this.rollCounter/this.rollTime);
			this.heroAnimator.SetTrigger("Dash");
			this.heroRigidBody.MovePosition(t * this.rollEndPos + this.rollStartPos * (1.0f - t));
		}

		if(this.rollCounter > this.rollTime) {
			this.isPlayerInRoll = false;
			this.isPlayerInputsDisabled = false;
			this.isPlayerInvulnerable = false;
			this.rollCounter = 0.0f;
			this.heroSprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}

		// Parry, o Onitorrinco

		// GetMouseButtonDown parameter
		// 0 -> primary
		// 1 -> secondary
		// 2 -> middle
		
		if(!this.isPlayerInputsDisabled) {
			if(Input.GetMouseButtonDown(0)) {
				Debug.Log("Parry, o Onitorrinco!");
				GameObject[] bullets = GameObject.FindGameObjectsWithTag(this.bulletTag);
				bool foundBulletToParry = false;
				float minAngle = 361.0f;
				GameObject parriedBullet = null;
				foreach(GameObject bullet in bullets) {
					if(this.isBulletReadyToParry(bullet)) {
						var v3 = Input.mousePosition;
						v3.z = 0.0f;
						v3 = gameCamera.ScreenToWorldPoint(v3);
						Vector2 bulletPos = new Vector2(bullet.transform.position.x - hero.transform.position.x,
														bullet.transform.position.y - hero.transform.position.y);
						Vector2 mousePos = new Vector2(v3.x - hero.transform.position.x,
														v3.y - hero.transform.position.y);
						float bulletAngle = Vector2.Angle(bulletPos, mousePos);
						if(bulletAngle < minAngle) {
							minAngle = bulletAngle;
							parriedBullet = bullet;
							foundBulletToParry = true;
						}
					}
				}
				if(foundBulletToParry) {
					// PARRY SUCCESS
					Debug.Log("Parry success!");
					BulletMovement bulletMovScript = parriedBullet.GetComponent<BulletMovement>();
					bulletMovScript.movementDirection *= -1.0f;
					bulletMovScript.movementSpeed *= 1.2f;
					isPlayerInParrySuccess = true;
					this.isPlayerInvulnerable = true;
					this.isPlayerInputsDisabled = true;
					this.parrySuccessIvencibilityCounter = 0.0f;
					Color c = this.heroSprite.color;
					c.a = 0.5f;
					this.heroSprite.color = c;
					this.heroAnimator.SetTrigger("Parry");
				} else {
					// PARRY FAIL
					Debug.Log("Parry fail!");
					isPlayerInParryFail = true;
					this.isPlayerInvulnerable = false;
					this.isPlayerInputsDisabled = true;
					this.parryFailIvencibilityCounter = 0.0f;
					Color c = this.heroSprite.color;
					c.b = 0.5f;
					c.g = 0.5f;
					this.heroSprite.color = c;
					this.heroAnimator.SetTrigger("Parry");
				}

			}
		}

		if(this.isPlayerInParrySuccess) {	
			this.parrySuccessIvencibilityCounter += Time.deltaTime;
		}
		if(this.isPlayerInParryFail) {	
			this.parryFailIvencibilityCounter += Time.deltaTime;
		}
		if(this.parrySuccessIvencibilityCounter > this.parrySuccessInvencibilityTime) {
			this.isPlayerInParrySuccess = false;
			this.isPlayerInvulnerable = false;
			this.isPlayerInputsDisabled = false;
			this.parrySuccessIvencibilityCounter = 0.0f;
			this.heroSprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}
		if(this.parryFailIvencibilityCounter > this.parryFailInvencibilityTime) {
			this.isPlayerInParryFail = false;
			this.isPlayerInvulnerable = false;
			this.isPlayerInputsDisabled = false;
			this.parryFailIvencibilityCounter = 0.0f;
			this.heroSprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}
	}

	private bool isBulletReadyToParry(GameObject bullet) {
		Vector3 bulletDir = bullet.transform.position - this.hero.transform.position;
		Vector2 bulletDir2 = new Vector2(bulletDir.x, bulletDir.y);
		var v3 = Input.mousePosition;
		v3.z = 0.0f;
		v3 = gameCamera.ScreenToWorldPoint(v3);
		Vector3 mouseDir = v3 - this.hero.transform.position;
		Vector2 mouseDir2 = new Vector2(mouseDir.x, mouseDir.y);
		Vector3 bulletMoveDir = bullet.GetComponent<BulletMovement>().movementDirection;
		Vector2 bulletMoveDir2 = new Vector2(bulletMoveDir.x, bulletMoveDir.y);
		if(bulletDir2.magnitude > this.parryRadius) return false;
		Debug.Log(Vector2.Angle(bulletDir2, mouseDir2));
		if(Vector2.Angle(bulletDir2, mouseDir2) > this.parryAngle) return false;
		if(Vector2.Dot(bulletMoveDir2.normalized, -1.0f*(mouseDir2.normalized)) < 0.0f) return false;
		return true;
	}
}

/*
DIST_MINIMA = 1 personagem de tamanho
ANGULO_MINIMO = 10 graus

- o jogador aperta o botao de parry (mouse esquerdo, por exemplo)
- pega a bala mais perto do jogador. vamos chamar ela de B

- vBala = B.pos - Jogador.pos
- vMouse = posicaoDoMouse - Jogador.pos
- dirBala = direcao da bala

- if(tamanho do vetor vBala > DIST_MINIMA) O PARRY NAO OCORRE
- if(angulo entre vBala e vMouse > ANGULO_MINIMO) O PARRY NAO OCORRE
- if(dot(dirBala.normalized, (-vMouse).normalized) < 0) O PARRY NAO OCORRE // angulo entre dirBal e -vMouse é menor que 90 gaus

- caso nada disso ocorra, O PARRY OCORRE

QUANDO O PARRY OCORRE:
  - o jogador fica invulneravel
  - desabilita movimento e rotaçao com mouse do jogador
  - o jogador roda uma animacao de parry
  - reabilita movimento e rotaçao com mouse do jogador
  - o jogador volta a ficar vulneravel

QUANDO O PARRY NAO OCORRE:
  - desabilita movimento e rotaçao com mouse do jogador
  - o jogador roda uma animacao de fail parry
  - reabilita movimento e rotaçao com mouse do jogador
*/