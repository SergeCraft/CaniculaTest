using System;
using System.Collections;
using Config;
using UnityEngine;
using Zenject;

namespace Placeables
{
    public class UniversalPlaceableView: MonoBehaviour
    {
        public IEnumerator actualMove;
        public  Vector3 direction;
        public float maxWidth;
        public float minWidth;
        public float movespeed;
        public float width;
        
        [Inject]
         public void Construct(InitArgs args)
         {
             movespeed = args.Movespeed;
             maxWidth = GameObject.Find("Background").GetComponent<RectTransform>().rect.width/2;
             minWidth = -maxWidth;
             direction = args.Direction;
             transform.position = args.Position + new Vector3(
                 -args.Config.Pivot.x,
                 -args.Config.Pivot.y,
                 args.Config.PosZ);
             
             var spriteRenderer = GetComponent<SpriteRenderer>();
            
             Sprite spriteToAdd = null;
            
             switch (args.Type)
             {
                 case PlaceableTypes.Ball:
                     spriteToAdd = Resources.Load<Sprite>("3rdParty/Canicula/Textures/ball");
                     break;
                 case PlaceableTypes.Cloud:
                     spriteToAdd = Resources.Load<Sprite>("3rdParty/Canicula/Textures/cloud_01");
                     break;
                 case PlaceableTypes.Palm:
                     spriteToAdd = Resources.Load<Sprite>("3rdParty/Canicula/Textures/palm");
                     break;
                 case PlaceableTypes.Sun:
                     spriteToAdd = Resources.Load<Sprite>("3rdParty/Canicula/Textures/sun");
                     break;
                 case PlaceableTypes.SeaStar:
                     spriteToAdd = Resources.Load<Sprite>("3rdParty/Canicula/Textures/star");
                     break;
             }

             spriteRenderer.sprite = spriteToAdd;
             transform.localScale = args.Config.Scale;
             width = spriteRenderer.sprite.bounds.size.x * args.Config.Scale.x;
         }

         private void Awake()
         {
             actualMove = DoMove();
             StartCoroutine(actualMove);
         }


         private IEnumerator DoMove()
        {
            while (true)
            {
                if (transform.position.x - width > maxWidth)
                {
                    transform.position = new Vector3(minWidth - width / 2, transform.position.y, transform.position.z);
                }
                else if (transform.position.x + width < minWidth)
                {
                    transform.position = new Vector3(maxWidth + width / 2, transform.position.y, transform.position.z);
                };
                
                transform.position += direction * movespeed * Time.deltaTime;

                yield return new WaitForFixedUpdate();
            }
        }
        
        
        public class Factory : PlaceholderFactory<InitArgs, UniversalPlaceableView>
        {
            
        }

        public class InitArgs
        {
            public Vector3 Direction { get; private set; }
            public float Movespeed { get; private set; }
            public Vector3 Position { get; private set; }
            public PlaceableTypes Type { get; private set; }
            
            public GameConfig.PlaceableConfig Config { get; private set; }

            public InitArgs(
                PlaceableTypes type, 
                Vector3 position,
                Vector3 direction,
                float movespeed,
                GameConfig.PlaceableConfig config)
            {
                Type = type;
                Position = position;
                Direction = direction;
                Movespeed = movespeed;
                Config = config;
            }
        }
    }
}