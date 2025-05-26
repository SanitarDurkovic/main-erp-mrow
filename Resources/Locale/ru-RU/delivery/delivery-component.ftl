delivery-recipient-examine = Это для { $recipient }, { $job }.
delivery-already-opened-examine = Уже открыта.
delivery-earnings-examine = Delivering this will earn the station [color=yellow]{ $spesos }[/color] spesos.
delivery-recipient-no-name = Без имени
delivery-recipient-no-job = Неизвестно
delivery-unlocked-self = Вы разблокировали { $delivery } с помощью отпечатка пальца.
delivery-opened-self = Вы открываете { $delivery }.
delivery-unlocked-others = { CAPITALIZE($recipient) } разблокировал { $delivery } с отпечатком { POSS-ADJ($possadj) }.
delivery-opened-others = { CAPITALIZE($recipient) } открыл { $delivery }.
delivery-unlock-verb = Открыть
delivery-open-verb = Открыто
delivery-slice-verb = Вскрыть
delivery-teleporter-amount-examine =
    { $amount ->
        [one] Содержит [color=yellow]{ $amount }[/color] доставку.
       *[other] Содержит [color=yellow]{ $amount }[/color] доставок.
    }
delivery-teleporter-empty = { $entity } пуст.
delivery-teleporter-empty-verb = Забрать почту
# modifiers
delivery-priority-examine = This is a [color=orange]priority { $type }[/color]. You have [color=orange]{ $time }[/color] left to deliver it to get a bonus.
delivery-priority-delivered-examine = This is a [color=orange]priority { $type }[/color]. It got delivered on time.
delivery-priority-expired-examine = This is a [color=orange]priority { $type }[/color]. It ran out of time.
delivery-fragile-examine = This is a [color=red]fragile { $type }[/color]. Deliver it intact for a bonus.
delivery-fragile-broken-examine = This is a [color=red]fragile { $type }[/color]. It looks badly damaged.
