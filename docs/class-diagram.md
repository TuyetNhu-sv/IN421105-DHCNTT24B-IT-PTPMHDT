```mermaid
---
config:
  layout: dagre
  class:
    hideEmptyMembersBox: false
  theme: neutral
  look: classic
  fontFamily: '''Recursive Variable'', sans-serif'
  themeVariables:
    fontFamily: '''Recursive Variable'', sans-serif'
---
classDiagram
direction TB
    class Club {
	    +Guid Id*
	    +string Name
	    +string Description
	    +DateTime CreatedAt
	    +IReadOnlyList~Member~ Members
	    +AddMember(Member)
	    +MemberCount() int
    }

    class Event {
	    +Guid Id*
	    +Guid ClubId*
	    +string Title
	    +DateTime Date
	    +int Capacity
	    +bool IsOnline
	    +HasCapacity(int) bool
    }

    class CheckIn {
	    +Guid Id*
	    +Guid RegistrationId*
	    +DateTime CheckedInAt
	    +string Method
	    +Summary() string
    }

    class Member {
	    +Guid Id*
	    +string Name
	    +string Email
	    +string StudentCode
	    +DateTime JoinedAt
	    +MemberStatus Status
	    +IsActive() bool
	    +Deactivate()
    }

    class Registration {
	    +Guid Id*
	    +Guid MemberId*
	    +Guid EventId
	    +DateTime RegisteredAt
	    +string Status
	    +Confirm()
	    +Cancel()
    }

    Club "*" -- "*" Member : Tham gia
    Club "1" -- "1" Event : Tổ chức
    Registration "*" -- "1" Event : Nhận
    Registration "*" -- "1" Member : Nhận
    CheckIn "0" -- "1" Registration : Điểm danh
    Member "*" -- "*" Event : Đăng ký