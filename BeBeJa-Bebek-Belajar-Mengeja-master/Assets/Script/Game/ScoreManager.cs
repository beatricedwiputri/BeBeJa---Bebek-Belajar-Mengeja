public static class ScoreManager{

    private static int targetScore;

    public static void setScore(int score){
        targetScore = score;
    }

    public static int getScore(){
        return targetScore;
    }
}