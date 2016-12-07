using UnityEngine;
using System.Collections;

namespace Solstice.HoloLens
{
    public class Cursor : MonoBehaviour
    {
        [Tooltip("Maximum gaze distance for calculating a hit.")]
        public float MaxGazeDistance = 5.0f;

        public Gaze gaze;
        public GameObject off;

            // the cursor that's provided by a provider.
        private GameObject cursorObject;

        private void Awake()
        {
            gaze = GetComponent<Gaze>();
        }

        private void Update()
        {
            Vector3 Position = gaze.Position;
            Vector3 Normal = gaze.Normal;
            GameObject Object = gameObject;

            if (gaze.Hit)
            {
                Object = gaze.HitInfo.collider.gameObject;
            }

            CursorProvider Provider = Object.GetComponentInParent<CursorProvider>();
            if (Provider)
            {
                cursorObject = Provider.HoverCursor;
                cursorObject.gameObject.SetActive(true);
                cursorObject.transform.position = Position;
                cursorObject.transform.forward = Normal;
                if(gameObject != cursorObject)
                {
                    gameObject.SetActive(false);
                }
            } else
            {
                if (cursorObject)
                {
                    cursorObject.SetActive(false);
                }
                gameObject.SetActive(true);
                transform.position = Position;
                transform.forward = Normal;
                off.SetActive(!gaze.Hit);
            }
        }
    }
}
