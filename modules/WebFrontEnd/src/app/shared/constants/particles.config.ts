import {
  ClickMode,
  HoverMode,
  IOptions,
  MoveDirection,
  OutMode,
  RecursivePartial,
} from 'tsparticles-engine';

export const PARTICLE_CONFIG: RecursivePartial<IOptions> = {
  background: {
    color: {
      value: '#1e1f26',
    },
  },
  fpsLimit: 120,
  interactivity: {
    events: {
      onClick: {
        enable: false,
        mode: ClickMode.push,
      },
      onHover: {
        enable: true,
        mode: HoverMode.connect,
      },
      resize: true,
    },
    modes: {
      push: {
        quantity: 4,
      },
      repulse: {
        distance: 200,
        duration: 0.4,
      },
    },
  },
  particles: {
    color: {
      value: ['#03dac6', '#ff0266', '#000000'],
    },
    links: {
      color: {
        value: 'random',
      },
      consent: false,
      distance: 200,
      enable: true,
      frequency: 1,
      opacity: 0.4,
      shadow: {
        blur: 5,
        color: {
          value: '#000',
        },
        enable: false,
      },
      triangles: {
        enable: false,
        frequency: 1,
      },
      width: 1,
      warp: false,
    },
    collisions: {
      enable: true,
    },
    move: {
      direction: MoveDirection.none,
      enable: true,
      outModes: {
        default: OutMode.out,
      },
      random: false,
      speed: 2,
      straight: false,
    },
    number: {
      density: {
        enable: true,
        area: 800,
      },
      value: 80,
    },
    opacity: {
      value: 0.5,
    },
    shape: {
      type: 'bubble'
    },
    size: {
      value: { min: 1, max: 5 },
    },
  },
  detectRetina: true,
};
