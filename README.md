# This was added after the final.
Extra notes: The user is expected to have different accounts for different library items, where each account is responsible for its own system and can have its own limitations. All accounts are expected to be linked to a single LibraryUser account. So that all systems may know if the user violated any rules for other systems. For example, LibraryUser has the NoExpandedItemsPolicy() method, which allows you to check if there are any violations across all accounts for item deadlines. However, there is no single approach to communicating with the library user. This may cause side effects and unexpected behavior. Communication with the library user must be standard via the provided methods.


## FinalSDP
