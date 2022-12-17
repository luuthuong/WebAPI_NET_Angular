import {
	animate,
	AnimationTriggerMetadata,
	group,
	query,
	style,
	transition,
	trigger,
} from '@angular/animations';

interface IStateTrigger {
    enter: {
        default: string;
        trigger: string;
    };
    leave: {
        default: string;
        trigger: string;
    };
}

const slideDirectionBase = (stateTrigger: IStateTrigger) => [
    query(
		':enter, :leave',
		style({
			position: 'absolute',
			width: '100%',
			top: 0,
			left: 0,
		}),
		{
			optional: true,
		}
	),
	group([
		query(
			':enter',
			[
				style({
					left: stateTrigger.enter.default,
				}),
				animate('0.7s cubic-bezier(0.23, 1, 0.320, 1)'),
				style({
					left: stateTrigger.enter.trigger,
				}),
			],
			{
				optional: true,
			}
		),
        query(
			':leave',
			[
				style({
					left: stateTrigger.leave.default,
				}),
				animate('0.7s cubic-bezier(0.23, 1, 0.320, 1)'),
				style({
					left: stateTrigger.leave.default,
				}),
			],
			{
				optional: true,
			}
		),
	]),
]

const slideRight = slideDirectionBase({
    enter: {
        default: '100%',
        trigger: '0'
    },
    leave:{
        default: '0',
        trigger: '-100%'
    }
})

const slideLeft = slideDirectionBase({
    enter: {
        default: '-100%',
        trigger: '0'
    },
    leave:{
        default: '0',
        trigger: '100%'
    }
});

export const AnimationSlide = [
    trigger('animationSlideView',[
        transition(':increment', slideRight),
        transition(':decrement', slideLeft)
    ])
];
