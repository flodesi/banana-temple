using UnityEngine;
using System.Collections;


[RequireComponent(typeof(BoxCollider2D))]
public class PlayerCollisions : MonoBehaviour
{

    public LayerMask collisionMask;

    const float skinWidth = .015f;
    public int horizontalRayCount = 4;
    public int verticalRayCount = 4;
    public bool DoDebug = true;

    float horizontalRaySpacing;
    float verticalRaySpacing;

    BoxCollider2D boxCollider;
    RaycastOrigins raycastOrigins;
    public CollisionInfo collisions;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        CalculateRaySpacing();
        collisions = new CollisionInfo(horizontalRayCount * 2 + verticalRayCount * 2);
    }

    public void Move(Vector3 velocity)
    {
        if (velocity.x != 0)
        {
            HorizontalCollisions(ref velocity);
        }
        if (velocity.y != 0)
        {
            VerticalCollisions(ref velocity);
        }
        collisions.SupposedRawDelta = velocity;
        if (Time.deltaTime != 0)
        {
            collisions.SupposedDelta = velocity / Time.deltaTime;
        }
        else
        {
            collisions.SupposedDelta = velocity / Time.unscaledDeltaTime;
        }

        collisions.SupposedPosition = transform.position + velocity;
        transform.Translate(velocity);
    }

    public void MoveYFirst(Vector3 velocity)
    {
        if (velocity.y != 0)
        {
            VerticalCollisions(ref velocity, false);
        }
        if (velocity.x != 0)
        {
            HorizontalCollisions(ref velocity, true);
        }
        collisions.SupposedRawDelta = velocity;
        if (Time.deltaTime != 0)
        {
            collisions.SupposedDelta = velocity / Time.deltaTime;
        }
        else
        {
            collisions.SupposedDelta = velocity / Time.unscaledDeltaTime;
        }

        collisions.SupposedPosition = transform.position + velocity;
        transform.Translate(velocity);
    }

    void HorizontalCollisions(ref Vector3 velocity, bool accountY = false)
    {
        float directionX = Mathf.Sign(velocity.x);
        float rayLength = Mathf.Abs(velocity.x) + skinWidth;
        Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
        if (accountY)
        {
            rayOrigin += Vector2.up * velocity.y;
        }
        for (int i = 0; i < horizontalRayCount; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);
            if (DoDebug)
            {
                Debug.DrawRay(rayOrigin, Vector2.right * directionX * rayLength, Color.red);
            }
            if (hit)
            {
                
                velocity.x = (hit.distance - skinWidth) * directionX;
                rayLength = hit.distance;

                collisions.Left = directionX == -1;
                collisions.Right = directionX == 1;
            }
            rayOrigin += Vector2.up * horizontalRaySpacing;
        }
    }

    void VerticalCollisions(ref Vector3 velocity, bool accountX = true)
    {
        float directionY = Mathf.Sign(velocity.y);
        float rayLength = Mathf.Abs(velocity.y) + skinWidth;
        Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
        if (accountX)
        {
            rayOrigin += Vector2.right * velocity.x;
        }

        for (int i = 0; i < verticalRayCount; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);
            if (DoDebug)
            {
                Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLength, Color.red);
            }
            if (hit)
            {
                velocity.y = (hit.distance - skinWidth) * directionY;
                rayLength = hit.distance;

                collisions.Below = directionY == -1;
                collisions.Above = directionY == 1;
            }
            rayOrigin += Vector2.right * verticalRaySpacing;
        }
    }



    private void UpdateRaycastOrigins()
    {
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    public void PreUpdate()
    {
        UpdateRaycastOrigins();
        collisions.Reset();
    }

    void CalculateRaySpacing()
    {
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(skinWidth * -2);

        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }

    public struct CollisionInfo
    {
        public bool Above, Below;
        public bool Left, Right;
        public Vector2 SupposedDelta;
        public Vector2 SupposedPosition;
        public Vector2 SupposedRawDelta;
        public GameObject[] hitObjects;

        public CollisionInfo(int hitBuffer)
        {
            Above = Below = Left = Right = false;
            SupposedDelta = SupposedPosition = SupposedRawDelta = Vector2.zero;
            hitObjects = new GameObject[hitBuffer];
        }

        public void Reset()
        {
            Above = Below = false;
            Left = Right = false;
            SupposedDelta = Vector2.zero;
            SupposedPosition = Vector2.zero;
            SupposedRawDelta = Vector2.zero;
            for (int i = 0; i < hitObjects.Length; i++)
            {
                hitObjects[i] = null;
            }
        }
    }

}


