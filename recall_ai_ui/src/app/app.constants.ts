export type MOOD = {
  name: string;
  value: number,
  color: string;
  emoji: string;
}

export const MOODS: MOOD[] = [
  {
    name: 'NEUTRAL',
    value: 0,
    color: 'grey',
    emoji: '😐', // Neutral face emoji
  },
  {
    name: 'ANGER',
    value: 1,
    color: 'orange',
    emoji: '😡', // Angry face emoji
  },
  {
    name: 'DISGUST',
    value: 2,
    color: 'green',
    emoji: '🤢', // Nauseated face emoji
  },
  {
    name: 'FEAR',
    value: 3,
    color: 'yellow',
    emoji: '😨', // Fearful face emoji
  },
  {
    name: 'JOY',
    value: 4,
    color: 'blue',
    emoji: '😊', // Smiling face with smiling eyes emoji
  },
  {
    name: 'SADNESS',
    value: 5,
    color: 'purple',
    emoji: '😢', // Crying face emoji
  },
  {
    name: 'SURPRISE',
    value: 6,
    color: 'brown',
    emoji: '😲', // Astonished face emoji
  },
];
