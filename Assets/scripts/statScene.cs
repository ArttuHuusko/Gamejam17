using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class statScene : MonoBehaviour {

	public GameObject TopWall;
	public GameObject MidWall;
	public GameObject BotWall;

	public GameObject TopLeftCannon;
	public GameObject MidLeftCannon;
	public GameObject BotLeftCannon;
	public GameObject TopRightCannon;
	public GameObject MidRightCannon;
	public GameObject BotRightCannon;

	public GameObject Spawner;

	public playerHealth TopHealth;
	public playerHealth MidHealth;
	public playerHealth BotHealth;

	public boatCannons TopLeftLoaded;
	public boatCannons MidLeftLoaded;
	public boatCannons BotLeftLoaded;
	public boatCannons TopRightLoaded;
	public boatCannons MidRightLoaded;
	public boatCannons BotRightLoaded;

	public Spawner spawnStats;

	public Image TopLeftSprite;
	public Image MidLeftSprite;
	public Image BotLeftSprite;
	public Image TopRightSprite;
	public Image MidRightSprite;
	public Image BotRightSprite;

	public Sprite Loaded;
	public Sprite Unloaded;

	public Text TopHp;
	public Text MidHp;
	public Text BotHp;

	public Text WaveProgress;
	public Text Wavenumber;

	// Use this for initialization
	void Start () 
	{
		TopHealth = TopWall.GetComponent<playerHealth>();
		MidHealth = MidWall.GetComponent<playerHealth>();
		BotHealth = BotWall.GetComponent<playerHealth>();
		TopLeftLoaded = TopLeftCannon.GetComponent<boatCannons> ();
		MidLeftLoaded = MidLeftCannon.GetComponent<boatCannons> ();
		BotLeftLoaded = BotLeftCannon.GetComponent<boatCannons> ();
		TopRightLoaded = TopRightCannon.GetComponent<boatCannons> ();
		MidRightLoaded = MidRightCannon.GetComponent<boatCannons> ();
		BotRightLoaded = BotRightCannon.GetComponent<boatCannons> ();
		spawnStats = Spawner.GetComponent<Spawner> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		TopHp.text = TopHealth.health.ToString();
		MidHp.text = MidHealth.health.ToString();
		BotHp.text = BotHealth.health.ToString();

		WaveProgress.text = "Enemies Killed: " + spawnStats.waveProgress + "/" + spawnStats.currentWave;
		Wavenumber.text = "Wave: " + spawnStats.waveCounter;
		if (TopLeftLoaded.cannonLoaded == true) 
		{
			TopLeftSprite.sprite = Loaded;
		} 
		else 
		{
			TopLeftSprite.sprite = Unloaded;
		}
		if (MidLeftLoaded.cannonLoaded == true) 
		{
			MidLeftSprite.sprite = Loaded;
		}
		else 
		{
			MidLeftSprite.sprite = Unloaded;
		}
		if (BotLeftLoaded.cannonLoaded == true) 
		{
			BotLeftSprite.sprite = Loaded;
		}
		else 
		{
			BotLeftSprite.sprite = Unloaded;
		}
		if (TopRightLoaded.cannonLoaded == true) 
		{
			TopRightSprite.sprite = Loaded;
		}
		else 
		{
			TopRightSprite.sprite = Unloaded;
		}
		if (MidRightLoaded.cannonLoaded == true) 
		{
			MidRightSprite.sprite = Loaded;
		}
		else 
		{
			MidRightSprite.sprite = Unloaded;
		}
		if (BotRightLoaded.cannonLoaded == true) 
		{
			BotRightSprite.sprite = Loaded;
		}
		else 
		{
			BotRightSprite.sprite = Unloaded;
		}
	}
}
