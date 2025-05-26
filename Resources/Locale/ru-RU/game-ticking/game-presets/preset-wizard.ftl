## Survivor

roles-antag-survivor-name = Выживший
# It's a Halo reference
roles-antag-survivor-objective = Текущая цель: Выжить
survivor-role-greeting =
    Вы - Выживший.
    Прежде всего, вам нужно вернуться в ЦентрКом живым.
    Соберите столько огневой мощи, сколько необходимо, чтобы гарантировать своё выживание.
    Никому не доверяйте.
survivor-round-end-dead-count =
    { $deadCount ->
        [one] [color=red]{ $deadCount }[/color] выживший погиб.
       *[other] [color=red]{ $deadCount }[/color] выживших погибли.
    }
survivor-round-end-alive-count =
    { $aliveCount ->
        [one] [color=yellow]{ $aliveCount }[/color] выживший остался на станции.
       *[other] [color=yellow]{ $aliveCount }[/color] выживших остались на станции.
    }
survivor-round-end-alive-on-shuttle-count =
    { $aliveCount ->
        [one] [color=green]{ $aliveCount }[/color] выживший выбрался живым.
       *[other] [color=green]{ $aliveCount }[/color] выживших выбрались живыми.
    }

## Wizard

objective-issuer-swf = [color=turquoise]Федерация Космических Магов[/color]
wizard-title = Маг
wizard-description = На станции есть Маг! Никогда не знаешь, что он может сделать.
roles-antag-wizard-name = Маг
roles-antag-wizard-objective = Преподайте им урок, который они никогда не забудут.
wizard-role-greeting =
    ТЫ - Маг!
    Между Федерацией Космических Магов и NanoTrasen возникла напряжённость.
    Поэтому Федерация Космических Магов выбрала вас для визита на станцию.
    Устройте им хорошую демонстрацию своих сил.
    Что вы будете делать, решать вам, но помните, Космические Маги хотят, чтобы вы остались живы.
wizard-round-end-name = Маг

## TODO: Wizard Apprentice (Coming sometime post-wizard release)

