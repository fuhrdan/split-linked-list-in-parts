//*****************************************************************************
//** 725. Split Linked List in Parts  leetcode                               **
//*****************************************************************************


/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
/**
 * Note: The returned array must be malloced, assume caller calls free().
 */
struct ListNode** splitListToParts(struct ListNode* head, int k, int* returnSize) 
{
    // Initialize the return array
    struct ListNode** result = (struct ListNode**) malloc(k * sizeof(struct ListNode*));
    *returnSize = k;
    
    // Step 1: Count the total length of the linked list
    int totalLength = 0;
    struct ListNode* temp = head;
    while (temp != NULL) 
    {
        totalLength++;
        temp = temp->next;
    }

    // Step 2: Calculate the size of each part
    int baseSize = totalLength / k;        // Minimum size of each part
    int extraNodes = totalLength % k;      // Extra nodes to distribute

    // Step 3: Split the list
    struct ListNode* current = head;
    for (int i = 0; i < k; i++) 
    {
        result[i] = current; // Start of this part
        int partSize = baseSize + (extraNodes > 0 ? 1 : 0);  // Distribute extra nodes
        if (extraNodes > 0) 
        {
            extraNodes--;
        }

        // Step 4: Traverse to the end of the current part
        for (int j = 0; j < partSize - 1 && current != NULL; j++) 
        {
            current = current->next;
        }

        // Step 5: Break the list and move to the next part
        if (current != NULL) 
        {
            struct ListNode* next = current->next;
            current->next = NULL; // Break the link
            current = next;
        }
    }

    return result;
}