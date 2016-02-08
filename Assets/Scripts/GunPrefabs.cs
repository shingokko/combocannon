using UnityEngine;
using System.Collections;

public class GunPrefabs : MonoBehaviour
{
    [HideInInspector]
    public GameObject boneIngredient1;
    [HideInInspector]
    public GameObject boneIngredient2;
    [HideInInspector]
    public GameObject boneIngredient3;
    [HideInInspector]
    public GameObject plantIngredient1;
    [HideInInspector]
    public GameObject plantIngredient2;
    [HideInInspector]
    public GameObject plantIngredient3;
    [HideInInspector]
    public GameObject mineralIngredient1;
    [HideInInspector]
    public GameObject mineralIngredient2;
    [HideInInspector]
    public GameObject mineralIngredient3;
    [HideInInspector]
    public GameObject fluidIngredient1;
    [HideInInspector]
    public GameObject fluidIngredient2;
    [HideInInspector]
    public GameObject fluidIngredient3;

    // particles
    [HideInInspector]
    public GameObject boneParticles;
    [HideInInspector]
    public GameObject plantParticles;
    [HideInInspector]
    public GameObject mineralParticles;
    [HideInInspector]
    public GameObject fluidParticles;
    [HideInInspector]
    public GameObject boneCrazyParticles;
    [HideInInspector]
    public GameObject plantCrazyParticles;
    [HideInInspector]
    public GameObject mineralCrazyParticles;
    [HideInInspector]
    public GameObject fluidCrazyParticles;

    // actions
    [HideInInspector]
    public GameObject smoke;
    [HideInInspector]
    public GameObject boneBullet;
    [HideInInspector]
    public GameObject plantBullet;
    [HideInInspector]
    public GameObject mineralBullet;
    [HideInInspector]
    public GameObject fluidBullet;
    [HideInInspector]
    public GameObject boneMachineGun;
    [HideInInspector]
    public GameObject plantMachineGun;
    [HideInInspector]
    public GameObject mineralMachineGun;
    [HideInInspector]
    public GameObject fluidMachineGun;
    [HideInInspector]
    public GameObject boneFire;
    [HideInInspector]
    public GameObject plantFire;
    [HideInInspector]
    public GameObject mineralFire;
    [HideInInspector]
    public GameObject fluidFire;

    // extra actions
    [HideInInspector]
    public GameObject blueBullet;

    void LoadPrefabs()
    {
        // ingredients
        plantIngredient1 = (GameObject)Resources.Load("IngredientA_1");
        plantIngredient2 = (GameObject)Resources.Load("IngredientA_2");
        plantIngredient3 = (GameObject)Resources.Load("IngredientA_3");
        boneIngredient1 = (GameObject)Resources.Load("IngredientB_1");
        boneIngredient2 = (GameObject)Resources.Load("IngredientB_2");
        boneIngredient3 = (GameObject)Resources.Load("IngredientB_3");
        mineralIngredient1 = (GameObject)Resources.Load("IngredientC_1");
        mineralIngredient2 = (GameObject)Resources.Load("IngredientC_2");
        mineralIngredient3 = (GameObject)Resources.Load("IngredientC_3");
        fluidIngredient1 = (GameObject)Resources.Load("IngredientD_1");
        fluidIngredient2 = (GameObject)Resources.Load("IngredientD_2");
        fluidIngredient3 = (GameObject)Resources.Load("IngredientD_3");

        // particles
        boneParticles = (GameObject)Resources.Load("BoneParticles");
        plantParticles = (GameObject)Resources.Load("PlantParticles");
        mineralParticles = (GameObject)Resources.Load("MineralParticles");
        fluidParticles = (GameObject)Resources.Load("FluidParticles");
        boneCrazyParticles = (GameObject)Resources.Load("BoneCrazyParticles");
        plantCrazyParticles = (GameObject)Resources.Load("PlantCrazyParticles");
        mineralCrazyParticles = (GameObject)Resources.Load("MineralCrazyParticles");
        fluidCrazyParticles = (GameObject)Resources.Load("FluidCrazyParticles");

        // actions
        smoke = (GameObject)Resources.Load("Smoke");
        boneBullet = (GameObject)Resources.Load("BoneBullet");
        plantBullet = (GameObject)Resources.Load("PlantBullet");
        mineralBullet = (GameObject)Resources.Load("MineralBullet");
        fluidBullet = (GameObject)Resources.Load("FluidBullet");
        boneMachineGun = (GameObject)Resources.Load("BoneMachineGun");
        plantMachineGun = (GameObject)Resources.Load("PlantMachineGun");
        mineralMachineGun = (GameObject)Resources.Load("MineralMachineGun");
        fluidMachineGun = (GameObject)Resources.Load("FluidMachineGun");
        boneFire = (GameObject)Resources.Load("BoneFire");
        plantFire = (GameObject)Resources.Load("PlantFire");
        mineralFire = (GameObject)Resources.Load("MineralFire");
        fluidFire = (GameObject)Resources.Load("FluidFire");

        // extra actions
        blueBullet = (GameObject)Resources.Load("BlueBullet");
    }

    void Start()
    {
        LoadPrefabs();
    }
}
